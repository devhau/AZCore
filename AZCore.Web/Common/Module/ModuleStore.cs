using AZCore.Extensions;
using AZCore.Web.Configs;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public class ModuleStore
    {
        IViewResult ModuleContent { get { return (IViewResult)httpContext.Items[AZCoreWeb.KeyHtmlModule]; } set { httpContext.Items[AZCoreWeb.KeyHtmlModule] = value; } }

        HttpContext httpContext;
        private ModuleStore(HttpContext _httpContext) {
            httpContext = _httpContext;
        }
        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }

        private bool DoCheckRouter() {
            string path = this.httpContext.Request.Path.Value;
            IPagesConfig pageConfigs = this.httpContext.GetService<IPagesConfig>();
            if (path == "/")
            {
                DoModule(pageConfigs.UrlRealDefault, pageConfigs);
                return true;
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
                            DoModule(RealPath, pageConfigs);
                            return true;
                        }

                    }
                }
            }

            return false;
        }
        private void DoModule(string RealPath, IPagesConfig pageConfigs) {

            foreach (var key in httpContext.Request.Query.Keys)
            {
                RealPath = string.Format("{0}&{1}={2}", RealPath, key, httpContext.Request.Query[key]);
            }
            if (!RealPath.StartsWith("?")) {
                RealPath = "?"+ RealPath;
            }
            httpContext.Request.Path = "/";
            httpContext.Request.QueryString = new QueryString(RealPath);
            httpContext.BindRequestTo(this);

            var startup = httpContext.GetService<IStartup>();
            string AssemblyName = startup.AssemblyName;
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
                var typeModule = startup.GetType().Assembly.GetType(AssemblyModule);
                if (typeModule != null)
                {
                    var Module = httpContext.RequestServices.GetService(typeModule) as ModuleBase;
                    if (Module != null)
                    {
                        ModuleContent = Module.GetView().DoResult((mdo) =>
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
                    }
                    else {
                        AssemblyModule = "";
                    }
                }
                else
                {
                    AssemblyModule = "";
                }
            }

            if (string.IsNullOrEmpty(AssemblyModule))
            {
                AssemblyModule = string.Format("{0}.Web.Errors.NotFoundModule", AssemblyName);
                var typeModule = startup.GetType().Assembly.GetType(AssemblyModule);
                if (typeModule != null)
                {
                    var Module = httpContext.RequestServices.GetService(typeModule) as ModuleBase;
                    if (Module != null)
                    {
                        ModuleContent = Module.GetView().DoResult((mdo) =>
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
                    }
                }
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
            else {
                httpContext.Response.WriteAsync(ModuleContent.Html);
            }


        }
        public static bool Router(HttpContext httpContext) {

            return new ModuleStore(httpContext).DoCheckRouter();
        }
    }
}
