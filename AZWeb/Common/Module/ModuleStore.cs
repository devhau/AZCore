using AZCore.Extensions;
using AZWeb.Common.Module.Attr;
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
        IView ModuleContent { get { return (IView)httpContext.Items[AZCoreWeb.KeyHtmlModule]; } set { httpContext.Items[AZCoreWeb.KeyHtmlModule] = value; } }
        private bool IsModule { get; set; } = false; 
        private bool isAjax { get; set; } = false;
        HttpContext httpContext;
        IStartup startup;
        IPagesConfig pageConfigs;

        string AssemblyName;
        private ModuleStore(HttpContext _httpContext) {
            httpContext = _httpContext;
            isAjax = httpContext.IsAjax();
            startup = httpContext.GetService<IStartup>();
            pageConfigs = this.httpContext.GetService<IPagesConfig>();
            AssemblyName = startup.AssemblyName;
            this.method = httpContext.Request.Method.ToUpperFirstChart();
            this.h = this.h.ToUpperFirstChart();
            DoCheckAuth();
        }
        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }
        public string method { get; set; }
        private ModuleBase ModuleCurrent;
        private bool isError = false;
        private void DoCheckAuth() {
            
        }
        private bool DoCheckRouter()
        {
            string path = this.httpContext.Request.Path.Value;
            if (path != "/" && !path.EndsWith(pageConfigs.extenstion)) return false;
            if (path == "/")
            {
                DoModule(pageConfigs.UrlRealDefault);
            }
            else
            {
                foreach (var item1 in pageConfigs.Pages)
                {
                    foreach (var item2 in item1.Tags)
                    {
                        var RegexPath = new Regex(item2.ViturlPath);
                        if (RegexPath.IsMatch(path))
                        {
                            var mPath = RegexPath.Match(path);
                            List<object> paraObject = new List<object>();
                            for (var i = 1; i < mPath.Groups.Count - 1; i++)
                            {
                                paraObject.Add(mPath.Groups[i].Value);
                            }
                            var RealPath = string.Format(item2.Real, paraObject.ToArray());
                            DoModule(RealPath);
                        }
                    }
                }
            }
            string AssemblyModule;
            bool IsAuthModule = false;
            if (ModuleCurrent == null)
            {
                DoError("NotFound");
            }
            else
            {
                IsAuthModule = ModuleCurrent.GetType().GetAttribute<AuthAttribute>() != null;
            }

            var methodFunction = ModuleCurrent.GetType().GetMethod(string.Format("{0}{1}", method, h));

            if (!this.isError)
            {
                if (IsAuthModule)
                {
                    IsAuthModule = methodFunction.GetAttribute<NotAuthAttribute>() == null;
                }
                else
                {
                    IsAuthModule = methodFunction.GetAttribute<AuthAttribute>() != null;
                }
                if (IsAuthModule && !ModuleCurrent.IsAuth)
                {
                    httpContext.Response.Redirect(pageConfigs.UrlLogin);
                    return true;
                }
            }
            List<object> paraValues = new List<object>();
            foreach (var param in methodFunction.GetParameters())
            {
                if (this.httpContext.Request.Query.ContainsKey(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Query[param.Name][0].Split(',').Select(p => Convert.ChangeType(p, type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(Convert.ChangeType(this.httpContext.Request.Query[param.Name].ToArray()[0], param.ParameterType));
                    }

                }
                else if (this.httpContext.Request.HasFormContentType && this.httpContext.Request.Form.Keys.Contains(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Form[param.Name][0].Split(',').Select(p => Convert.ChangeType(p, type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(Convert.ChangeType(this.httpContext.Request.Form[param.Name].ToArray()[0], param.ParameterType));
                    }

                }
                else
                {
                    if (param.HasDefaultValue)
                        paraValues.Add(param.RawDefaultValue);
                    else
                        paraValues.Add(null);
                }
            }
            var rsFN = methodFunction.Invoke(ModuleCurrent, paraValues.ToArray());
            if (rsFN is Task)
            {
                ((Task<IView>)rsFN).Wait();
            }


            if (ModuleCurrent.IsTheme && !this.isError& !isAjax)
            {
                AssemblyModule = string.Format("{0}.Web.Themes.{1}.LayoutTheme", AssemblyName, pageConfigs.Theme);
                var typeModule = startup.GetType().Assembly.GetType(AssemblyModule);
                if (typeModule != null)
                {
                    httpContext.GetService<ThemeBase>(typeModule)?.RenderSite();
                }
            }
            else
            {
                if (isAjax)
                {
                    ModuleCurrent.RenderJson();
                }
                else
                {
                    ModuleCurrent.RenderSite();
                }
            }

            return true;
        }
        private void DoError(string error) {
            this.h = "";
            this.method = "Get";
            this.isError = true;
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
            var TempQuery = new QueryString(RealPath);
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
                ModuleCurrent = httpContext.RequestServices.GetService(typeModule) as ModuleBase;
                if (ModuleCurrent != null)
                {                   
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
