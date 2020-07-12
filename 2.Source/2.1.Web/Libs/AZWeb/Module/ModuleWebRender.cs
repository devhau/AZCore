using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Constant;
using AZWeb.Module.Page;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace AZWeb.Module
{
   public sealed class ModuleWebRender
    {
        RenderView renderView;
        HttpContext httpContext;
        bool IsAjax { get; }
        readonly string urlPath;
        IPermissionService permissionService = null;
        ModuleWebRender(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            renderView = httpContext.GetRenderView();
            permissionService = httpContext.GetService<IPermissionService>();
            this.IsAjax = httpContext.IsAjax();
            urlPath = this.httpContext.Request.Path.Value;
            this.httpContext.Items[AZWebConstant.KeyUrlCurrent] = string.Format("{0}{1}", urlPath, this.httpContext.Request.QueryString.Value);
          
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
                this.httpContext.Items[AZWebConstant.KeyTenant] = User?.TenantId;
            }
        }

        /// <summary>
        /// Load Module
        /// </summary>
        /// <param name="AssemblyModule"></param>
        /// <returns></returns>
        private ModuleBase LoadModule(string AssemblyModule)
        {
            var key = AssemblyModule.ToLower().Trim();
            if (ModuleWebInfo.dicModule.ContainsKey(key))
            {
                return httpContext.RequestServices.GetService(ModuleWebInfo.dicModule[key]) as ModuleBase;
            }
            return null;
        }
        /// <summary>
        /// Get Module
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CheckModule()
        {
            #region --- Get Module & Process Module ----
          
          
            //Kiểm tra xem hệ thống đã đăng nhập chưa.
            this.CheckIdentity();
            //
            if (!(httpContext.Items[ModuleWebInfo.Key] is ModuleWebInfo moduleInfo)) return false;
            //
            var methodName = moduleInfo.MethodName;
            //
            var moduleName = moduleInfo.ModulePath;

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
                return false;
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
                return true;
            } else if (rsView is RedirectView) {
                await renderView.RenderRedirect(rsView as RedirectView);
                return true;
            } else if (rsView is JsonView)
            {
                await renderView.RenderJson(rsView as JsonView);
                return true;
            }
            #endregion

            #region --- Get Theme && Process Theme ---
            if (ModuleCurrent is PageModule) {
                var PageCurrent = ModuleCurrent as PageModule;
                if (PageCurrent.IsTheme & !IsAjax)
                {
                    string typeThemeString = string.Format("Web.Themes.{0}.LayoutTheme", PageCurrent.ThemeName??"Default").ToLower();
                    if (!ModuleWebInfo.dicModule.ContainsKey(typeThemeString))
                        return false;
                    var theme = httpContext.GetService<ThemeBase>(ModuleWebInfo.dicModule[typeThemeString]);

                    if (theme == null)
                        return false;
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

            return true;
        }
        public static async Task<bool> RouterAsync(HttpContext httpContext) {
            
            return await new ModuleWebRender(httpContext).CheckModule();
        }
    }
}
