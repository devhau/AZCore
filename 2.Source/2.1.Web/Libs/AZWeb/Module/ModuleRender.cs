using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Constant;
using AZWeb.Module.Page;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    sealed class ModuleRender
    {
        internal static IHostingEnvironment _hostingEnvironment;
        private enum RenderError
        {
            None,
            NoAuth,
            NoPermission,
            NotFoundModule,
            NotFoundMethod,
            NotFoundPath,
            NotFoundTheme,
            OK

        }
        RenderView renderView;
        HttpContext httpContext;
        readonly IPagesConfig PageConfigs = null;
        bool IsAjax { get; }
        readonly string urlPath;
        IPermissionService permissionService = null;
        ITenantService tenantService = null;
        ModuleRender(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            renderView = httpContext.GetRenderView();
            permissionService = httpContext.GetService<IPermissionService>();
            tenantService = httpContext.GetService<ITenantService>();
            this.PageConfigs = this.httpContext.GetService<IPagesConfig>();
            this.IsAjax = httpContext.IsAjax();
            urlPath = this.httpContext.Request.Path.Value;
            this.httpContext.Items[AZWebConstant.KeyUrlCurrent] = string.Format("{0}{1}", urlPath, this.httpContext.Request.QueryString.Value);
            if (_hostingEnvironment == null) {
                _hostingEnvironment = _httpContext.GetService<IHostingEnvironment>();
            }
        }
        private void CheckIdentity()
        {
            if (this.httpContext.User.Identity.IsAuthenticated)
            {
                var User = this.httpContext.User.GetUserInfo();
                if (permissionService != null)
                {
                    User.PermissionActive = permissionService.GetPermissionByUserId(User.Id).ToList();
                }
                this.httpContext.Items[AZWebConstant.KeyUser] = User;
            }
        }

        /// <summary>
        /// Get Path Real
        /// </summary>
        /// <returns> Path Real </returns>
        private string GetPathReal()
        {
            if (urlPath == "/")
            {
                return PageConfigs.UrlRealDefault;
            }
            else
            {
                foreach (var item1 in PageConfigs.Pages)
                {
                    foreach (var item2 in item1.Tags)
                    {
                        // /^\/product\/(\d+)/
                        var RegexPath = new Regex(string.Format("/{0}", item2.ViturlPath));
                        if (RegexPath.IsMatch(urlPath))
                        {
                            var rs = RegexPath.Replace(urlPath, item2.Real);
                            return !item2.Group.IsNullOrEmpty() ? string.Format("{0}&gm={1}", rs, item2.Group) : rs;
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
        private ModuleBase LoadModule(string AssemblyModule)
        {
            var typeModule = this.GetType(AssemblyModule);
            if (typeModule != null)
            {
                return httpContext.RequestServices.GetService(typeModule) as ModuleBase;
            }
            return null;
        }
        private KeyValuePair<string, string> GetModuleAndHandle() {
            string ModuleStr = string.Empty;
            string methodName = string.Empty;

            if (urlPath == "/" || urlPath.EndsWith(PageConfigs.extenstion))
            {
                var pathReal = GetPathReal();
                if (string.IsNullOrEmpty(pathReal))
                {
                }
                else
                {
                    foreach (var key in httpContext.Request.Query.Keys)
                    {
                        pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
                    }
                    var query = QueryHelpers.ParseQuery(pathReal);
                    if (!query.ContainsKey("m") || string.IsNullOrEmpty(query["m"].ToString())) return default;
                    string moduleName = query["m"].ToString();
                    string viewName = moduleName;
                    if (query.ContainsKey("v") && !string.IsNullOrEmpty(query["v"].ToString()))
                        viewName = query["v"].ToString();
                    string gm = "";
                    if (query.ContainsKey("gm") && !string.IsNullOrEmpty(query["gm"].ToString()))
                        gm = "." + query["gm"].ToString();
                    ModuleStr = string.Format("Web.Modules{2}.{0}.Form{1}", moduleName, viewName, gm);
                    methodName = httpContext.Request.Method;
                    if (query.ContainsKey("h") && !string.IsNullOrEmpty(query["h"].ToString()))
                        methodName = string.Format("{0}{1}", methodName, query["h"].ToString());
                    httpContext.Request.QueryString = new QueryString(string.Format("?{0}", pathReal));
                } 
            }
            else if (urlPath.StartsWith("/api/"))
            {
                var methodNameIndex = urlPath.LastIndexOf("/");
                methodName = "{0}{1}".Frmat(httpContext.Request.Method, urlPath.Substring(methodNameIndex + 1));
                ModuleStr = "Web.Api.{0}Controller".Frmat(urlPath.Substring(5, methodNameIndex - 5).Replace("/", "."));
            }
            else if (urlPath.EndsWith(".az")) {
               
            }
            return new KeyValuePair<string, string>(ModuleStr, methodName);
        }
        /// <summary>
        /// Get Module
        /// </summary>
        /// <returns></returns>
        private async Task<RenderError> GetModule()
        {
            #region --- Get Module & Process Module ----
          
          
            //Kiểm tra xem hệ thống đã đăng nhập chưa.
            this.CheckIdentity();
            //
            var moduleInfo = GetModuleAndHandle();
            //
            var methodName = moduleInfo.Value;
            //
            var moduleName = moduleInfo.Key;
            if (methodName.IsNullOrEmpty()||methodName.IsNullOrEmpty())
            {

                methodName = "Get";
                moduleName = string.Format("Web.Errors.NotFound");
            }
            //
            var ModuleCurrent = LoadModule(moduleName);

            if (ModuleCurrent == null|| (ModuleCurrent.GetType().GetAttribute<OnlyAjaxAttribute>() != null && !IsAjax))
            {

                methodName = "Get";
                moduleName = string.Format("Web.Errors.NotFound");
                ModuleCurrent = LoadModule(moduleName);
            }

            var methodFunction = ModuleCurrent.GetType().GetMethods().FirstOrDefault(p=> string.Equals(p.Name, methodName, StringComparison.OrdinalIgnoreCase));
            if (methodFunction == null || (methodFunction.GetAttribute<OnlyAjaxAttribute>() != null && !IsAjax))
            {
                methodName = "Get";
                moduleName = string.Format("Web.Errors.NotFound");
                ModuleCurrent = LoadModule(moduleName);
                methodFunction = ModuleCurrent.GetType().GetMethods().FirstOrDefault(p => string.Equals(p.Name, methodName, StringComparison.OrdinalIgnoreCase));
            }
           
            ModuleCurrent.BeforeRequest();
            var isModuleAuth= ModuleCurrent.GetType().GetAttribute<AuthAttribute>()!=null;
            var isMethodAuth = methodFunction.GetAttribute<AuthAttribute>() != null;
            var isMethodNotAuth = methodFunction.GetAttribute<NotAuthAttribute>() != null;
            if (((isModuleAuth && !isMethodNotAuth) || isMethodAuth)&&!ModuleCurrent.IsAuth) {
                var redirectView = ModuleCurrent.GoToAuth().As<RedirectView>();
                if (IsAjax)
                {
                    await renderView.RenderJson(new JsonView() { Module = ModuleCurrent, StatusCode = System.Net.HttpStatusCode.Unauthorized, Data = redirectView.RedirectToUrl });
                }
                else
                {
                    httpContext.Response.Redirect(redirectView.RedirectToUrl);
                }
                return RenderError.OK;
            }

            #region Bind Param action
            List<object> paraValues = new List<object>();
            foreach (var param in methodFunction.GetParameters())
            {
                BindFormAttribute attr = null;
                if ((attr = param.GetAttribute<BindFormAttribute>()) != null)
                {
                    paraValues.Add(httpContext.GetObjectValueByForm(param.ParameterType, string.IsNullOrEmpty(attr.FromName)? param.Name: attr.FromName));
                }
                else {
                    var attr1 = param.GetAttribute<BindQueryAttribute>();
                    paraValues.Add(httpContext.GetObjectValueByQuery(param.ParameterType,( attr1==null|| string.IsNullOrEmpty(attr1.FromName)) ? param.Name : attr1.FromName));
                }
            }
            #endregion

            Common.IView rsView = null;
            var rsFN = methodFunction.Invoke(ModuleCurrent, paraValues.ToArray());
            if (rsFN is Task)
            {
                rsView = await (Task<Common.IView>)rsFN;
            }
            else
            {
                rsView = (Common.IView)rsFN;
            }
            ModuleCurrent.AfterRequest();

            #endregion

            #region --- Check Download File && Download file ---
            if (rsView is DownloadFileView)
            {
                await renderView.RenderFile(rsView as DownloadFileView);
                return RenderError.OK;
            } else if (rsView is RedirectView) {
                await renderView.RenderRedirect(rsView as RedirectView);
                return RenderError.OK;
            } else if (rsView is JsonView)
            {
                await renderView.RenderJson(rsView as JsonView);
                return RenderError.OK;

            }
            #endregion

            #region --- Get Theme && Process Theme ---
            if (ModuleCurrent is PageModule) {
                var PageCurrent = ModuleCurrent as PageModule;
                if (PageCurrent.IsTheme & !IsAjax)
                {
                    string typeThemeString = string.Format("Web.Themes.{0}.LayoutTheme", PageCurrent.ThemeName??PageConfigs.Theme);
                    var typeTheme = this.GetType(typeThemeString);
                    if (typeTheme == null)
                        return RenderError.NotFoundTheme;
                    var theme = httpContext.GetService<ThemeBase>(typeTheme);

                    if (theme == null)
                        return RenderError.NotFoundTheme;
                    theme.BeforeRequest();
                    theme.LayoutTheme = PageCurrent.LayoutTheme;
                    theme.BodyContent = await renderView.GetContentHtmlFromView(rsView as HtmlView);
                    await renderView.RenderHtml(theme.GetTheme());
                    theme.AfterRequest();
                }
                else if (!IsAjax)
                {
                    await renderView.RenderHtml(rsView as HtmlView);
                }
                else
                {
                    var BodyContent = await renderView.GetContentHtmlFromView(rsView as HtmlView);
                    var htmlContent = PageCurrent.Html;
                    htmlContent.Html = BodyContent.GetString();
                    await renderView.RenderJson(htmlContent);
                }
            }
            #endregion

            return RenderError.OK;
        }

        private async Task<bool> GetError(RenderError error)
        {
            var ErrorString = "NotFound";
            string typeModuleString = string.Format("Web.Errors.{0}", ErrorString);
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
                Common.IView rsView = null;
                var rsFN = methodFunction.Invoke(errorModule, paraValues.ToArray());
                if (rsFN is Task)
                {
                    rsView = await (Task<IView>)rsFN;
                }
                else
                {
                    rsView = (Common.IView)rsFN;
                }
                errorModule.AfterRequest();
            }
            return true;
        }
       
        private async Task<bool> DoRouterAsync() {
            var statusModule = await GetModule();
            if (statusModule == RenderError.OK)
                return true;
            if (statusModule != RenderError.OK && statusModule != RenderError.None && statusModule != RenderError.NoAuth &&statusModule!= RenderError.NotFoundMethod && statusModule != RenderError.NotFoundMethod)
            {
                return await GetError(statusModule);
            }
            return false;
        }
        private Type GetType(string type)
        {
            return AZCoreExtensions.startup.GetType(type);
        }

        public static async Task<bool> RouterAsync(HttpContext httpContext) {
            
            return await new ModuleRender(httpContext).DoRouterAsync();
        }
    }
}
