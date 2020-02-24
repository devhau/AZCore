using AZCore.Extensions;
using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZWeb.Common.Module
{
    public class ModuleStore
    {
        IViewResult ModuleContent { get { return (IViewResult)httpContext.Items[AZCoreWeb.KeyHtmlModule]; } set { httpContext.Items[AZCoreWeb.KeyHtmlModule] = value; } }
        private bool IsModule { get; set; } = false;
        HttpContext httpContext;
        IStartup startup;
        IPagesConfig pageConfigs;
        string AssemblyName;
        private ModuleStore(HttpContext _httpContext) {
            httpContext = _httpContext;
            startup = httpContext.GetService<IStartup>();
            pageConfigs = this.httpContext.GetService<IPagesConfig>();
            AssemblyName = startup.AssemblyName;
        }
        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }

        private bool DoCheckRouter() {
            string path = this.httpContext.Request.Path.Value;
            if (path != "/" && !path.EndsWith(pageConfigs.extenstion)) return false;
            if (path == "/")
            {
                DoModule(pageConfigs.UrlRealDefault);
            }
            else {
                foreach (var item1 in pageConfigs.Pages)
                {
                    foreach (var item2 in item1.Tags)
                    {
                        var RegexPath = new Regex(item2.ViturlPath);
                        if (RegexPath.IsMatch(path)) {
                            var mPath = RegexPath.Match(path);
                            List<object> paraObject = new List<object>();
                            for (var i = 1; i < mPath.Groups.Count - 1; i++) {
                                paraObject.Add(mPath.Groups[i].Value);
                            }
                            var RealPath = string.Format(item2.Real, paraObject.ToArray());
                            DoModule(RealPath);
                        }
                    }
                }
            }
            string AssemblyModule;
           
            if (ModuleContent == null) {
                if (this.IsModule)
                    DoError("NotFoundMethod");
                else
                    DoError("NotFound");             
            }
            if (ModuleContent.IsTheme)
            {
                AssemblyModule = string.Format("{0}.Web.Themes.{1}.LayoutTheme", AssemblyName, pageConfigs.Theme);
                var typeModule = startup.GetType().Assembly.GetType(AssemblyModule);
                if (typeModule != null)
                {
                    var Theme = httpContext.RequestServices.GetService(typeModule) as ThemeBase;
                    if (Theme != null)
                    {
                        httpContext.Response.WriteAsync(Theme.GetHtml());
                    }
                }
            }
            else
            {
                httpContext.Response.WriteAsync(ModuleContent.Html);
            }

            return true;
        }
        private void DoError(string error) {
            if (!LoadModule(string.Format("{0}.Web.Errors.{1}", AssemblyName, error)))
            {
            }
        }
        private void DoModule(string RealPath) {

            foreach (var key in httpContext.Request.Query.Keys)
            {
                RealPath = string.Format("{0}&{1}={2}", RealPath, key, httpContext.Request.Query[key]);
            }
            if (!RealPath.StartsWith("?")) {
                RealPath = "?" + RealPath;
            }
            httpContext.Request.Path = "/";
            httpContext.Request.QueryString = new QueryString(RealPath);
            httpContext.BindRequestTo(this);

            string AssemblyModule = "";
            if (!string.IsNullOrEmpty(m))
            {
                if (string.IsNullOrEmpty(v))
                {
                    AssemblyModule = string.Format("{0}.Web.Modules.{1}.Form{1}", AssemblyName, m.ToUpperFirstChart());
                }
                else
                {
                    AssemblyModule = string.Format("{0}.Web.Modules.{1}.Form{2}", AssemblyName, m.ToUpperFirstChart(), v.ToUpperFirstChart());
                }
                if (!LoadModule(AssemblyModule)) {
                    AssemblyModule = "";
                }
            }

            if (string.IsNullOrEmpty(AssemblyModule))
            {
                DoError("NotFoundModule");               
            }

        }
         
        private bool LoadModule(string AssemblyModule)
        {
            var typeModule = startup.GetType().Assembly.GetType(AssemblyModule);
            if (typeModule != null)
            {
                var Module = httpContext.RequestServices.GetService(typeModule) as ModuleBase;
                if (Module != null)
                {
                    this.IsModule = true;
                    var vi = Module.GetView();
                    if (vi == null) {
                        ModuleContent = null;
                        return false;
                    }
                    vi.DoResult((mdo) =>
                    {
                        if (!httpContext.IsAjax() && pageConfigs != null)
                        {
                            if (pageConfigs.Head != null)
                            {
                                mdo.CSS.InsertRange(0, pageConfigs.Head.Stypes);
                                mdo.JS.InsertRange(0, pageConfigs.Head.Scripts);
                            }
                        }
                    });
                    return true;
                }
            }
            return false;
        } 
        public static bool Router(HttpContext httpContext) {
            return new ModuleStore(httpContext).DoCheckRouter();
        }
    }
}
