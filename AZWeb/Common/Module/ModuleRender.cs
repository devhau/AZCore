using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZWeb.Common.Module
{
    public class ModuleRender
    {
        private enum RenderError {
            None,
            NoAuth,            
            NoPermission,
            NotFoundModule,
            NotFoundMethod,
            NotFoundPath,
            NotFoundTheme,
            OK

        }
        IStartup startup;
        private  bool IsAjax { get; }
        private readonly HttpContext httpContext;
        private readonly string AzWebAssembly = "Web";
        private readonly IPagesConfig PageConfigs = null;
        private readonly UserInfo user;
        ModuleRender(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            this.user = httpContext.GetUser();
            this.PageConfigs = this.httpContext.GetService<IPagesConfig>();
            this.IsAjax = httpContext.IsAjax();
            startup = httpContext.GetService<IStartup>();
        }
        private Type GetType(string type) {
            return startup.GetType(type);
        }
        /// <summary>
        /// Get Path Real
        /// </summary>
        /// <returns> Path Real </returns>
        private string GetPathReal()
        {
            string path = this.httpContext.Request.Path.Value;
            if (path != "/" && !path.EndsWith(PageConfigs.extenstion)) return string.Empty;
            if (path == "/")
            {
                return PageConfigs.UrlRealDefault;
            }
            else
            {
                foreach (var item1 in PageConfigs.Pages)
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
                            return string.Format(item2.Real, paraObject.ToArray());
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Load Module
        /// </summary>
        /// <param name="AssemblyModule"></param>
        /// <returns></returns>
        private PageModule LoadModule(string AssemblyModule)
        {
            var typeModule = this.GetType(AssemblyModule);
            if (typeModule != null)
            {
                return httpContext.RequestServices.GetService(typeModule) as PageModule;               
            }
            return null;
        }
        /// <summary>
        /// Get Module
        /// </summary>
        /// <returns></returns>
        private RenderError GetModule() 
        {

            #region --- Get Path & Merge Path ---
            var pathReal = GetPathReal();
            if (string.IsNullOrEmpty(pathReal)) return RenderError.NotFoundPath;
            foreach (var key in httpContext.Request.Query.Keys)
            {
                pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
            }
            #endregion

            #region --- Get Module & Process Module ----
            var query = QueryHelpers.ParseQuery(pathReal);
            if(!query.ContainsKey("m")|| string.IsNullOrEmpty(query["m"].ToString())) return RenderError.NotFoundPath;
            string moduleName = query["m"].ToString().ToUpperFirstChart();
            string viewName = moduleName;
            if (query.ContainsKey("v") && !string.IsNullOrEmpty(query["v"].ToString()))
                 viewName = query["v"].ToString().ToUpperFirstChart();
            string typeModuleString = string.Format("{0}.Modules.{1}.Form{2}", AzWebAssembly, moduleName, viewName);
            var ModuleCurrent = LoadModule(typeModuleString);

            var methodName = httpContext.Request.Method.ToUpperFirstChart();
            if (query.ContainsKey("h") && !string.IsNullOrEmpty(query["h"].ToString()))
                methodName = string.Format("{0}{1}", methodName, query["h"].ToString().ToUpperFirstChart());

            if (ModuleCurrent == null)
                return RenderError.NotFoundModule;
            var methodFunction = ModuleCurrent.GetType().GetMethod(methodName);
            if (methodFunction == null)
                return RenderError.NotFoundMethod;
            if ((ModuleCurrent.GetType().GetAttribute<AuthAttribute>() != null && methodFunction.GetAttribute<NotAuthAttribute>() == null) || methodFunction.GetAttribute<AuthAttribute>() != null) {

                if (this.user == null) {
                    httpContext.Response.Redirect(PageConfigs.UrlLogin);
                    return RenderError.NoAuth;
                }
            }
            ModuleCurrent.BeforeRequest();
            
            httpContext.Request.QueryString = new QueryString(string.Format("?{0}", pathReal));
            List<object> paraValues = new List<object>();
            foreach (var param in methodFunction.GetParameters())
            {
                if (this.httpContext.Request.Query.ContainsKey(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Query[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(this.httpContext.Request.Query[param.Name].ToArray()[0].ToType(param.ParameterType));
                    }

                }
                else if (this.httpContext.Request.HasFormContentType && this.httpContext.Request.Form.Keys.Contains(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Form[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(this.httpContext.Request.Form[param.Name].ToArray()[0].ToType(param.ParameterType));
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
            ModuleCurrent.AfterRequest();

            #endregion
            #region --- Check Download File && Download file ---
            if (rsFN is FileView) {
                var fileView = rsFN.As<FileView>();
                var response = httpContext.Response;
                response.Clear();
                response.ContentType = fileView.ContentType;
                response.Headers["Content-Disposition"] = "attachment; filename=" + fileView.Name + ";";
                fileView.File.CopyToAsync(response.Body);
                response.Body.Flush();
                return RenderError.OK;
            } else if (rsFN is IRedirectView) {
                if (IsAjax)
                {
                    httpContext.Response.WriteAsync(rsFN.ToJson());
                }
                else {
                    httpContext.Response.Redirect(rsFN.As<IRedirectView>().Redirect);
                }
                return RenderError.OK;
            }
            #endregion
            #region --- Get Theme && Process Theme ---

                if (ModuleCurrent.IsTheme & !IsAjax)
            {
                string typeThemeString = string.Format("{0}.Themes.{1}.{2}", AzWebAssembly, PageConfigs.Theme, ModuleCurrent.LayoutTheme);
                var typeTheme = this.GetType(typeThemeString);
                if (typeTheme == null)
                    return RenderError.NotFoundTheme;
                var theme = httpContext.GetService<ThemeBase>(typeTheme);//?.RenderSite();

                if (theme == null)
                    return RenderError.NotFoundTheme;
                theme.BeforeRequest();
                theme.RenderSite();
                theme.AfterRequest();
            }
            else
            {
                if (IsAjax)
                {
                    ModuleCurrent.RenderJson();
                }
                else
                {
                    ModuleCurrent.RenderSite();
                }
            }
            #endregion

            return RenderError.OK;
        }
        private bool GetError(RenderError error) 
        {
            var ErrorString = "NotFound";
            string typeModuleString = string.Format("{0}.Errors.{1}", AzWebAssembly, ErrorString);
            var typeModule = this.GetType(typeModuleString);
            if (typeModule != null)
            {
                var errorModule = httpContext.RequestServices.GetService(typeModule) as PageModule;
                errorModule.BeforeRequest();
                var methodFunction = errorModule.GetType().GetMethod("Get");
                List<object> paraValues = new List<object>();
                foreach (var param in methodFunction.GetParameters())
                {
                    if (this.httpContext.Request.Query.ContainsKey(param.Name.ToLower()))
                    {
                        if (param.ParameterType.IsArray)
                        {
                            var type = param.ParameterType.GetElementType();
                            var obj = this.httpContext.Request.Query[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                            paraValues.Add(obj);
                        }
                        else
                        {
                            paraValues.Add(this.httpContext.Request.Query[param.Name].ToArray()[0].ToType(param.ParameterType));
                        }

                    }
                    else if (this.httpContext.Request.HasFormContentType && this.httpContext.Request.Form.Keys.Contains(param.Name.ToLower()))
                    {
                        if (param.ParameterType.IsArray)
                        {
                            var type = param.ParameterType.GetElementType();
                            var obj = this.httpContext.Request.Form[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                            paraValues.Add(obj);
                        }
                        else
                        {
                            paraValues.Add(this.httpContext.Request.Form[param.Name].ToArray()[0].ToType(param.ParameterType));
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
                var rsFN = methodFunction.Invoke(errorModule, paraValues.ToArray());
                if (rsFN is Task)
                {
                    ((Task<IView>)rsFN).Wait();
                }
                errorModule.AfterRequest();
            }
            return true;
        }
        private bool DoRender() 
        {
            var statusModule = GetModule();
            if (statusModule != RenderError.OK && statusModule != RenderError.None && statusModule != RenderError.NoAuth) {
                return GetError(statusModule);
            }
            return true;
        }
        public static bool Router(HttpContext httpContext)
        {
            return new ModuleRender(httpContext).DoRender();
        }
    }
}
