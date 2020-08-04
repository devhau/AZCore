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
        IIdentityService permissionService = null;
        ModuleWebRender(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            renderView = httpContext.GetRenderView();
            permissionService = httpContext.GetService<IIdentityService>();
            this.IsAjax = httpContext.IsAjax();
          
        }
        private void CheckIdentity()
        {
            if (this.httpContext.User.Identity.IsAuthenticated)
            {
                var User = this.httpContext.User.GetUserInfo();
                if (permissionService != null)
                {
                    User.PermissionActive = permissionService.GetPermissionByUserId(User.Id).ToList();
                    User.TenantId = permissionService.GetTenantByUserId(User.Id);
                }
                this.httpContext.Items[AZWebConstant.KeyUser] = User;
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
            if (WebInfo.dicModule.ContainsKey(key))
            {
                return httpContext.RequestServices.GetService(WebInfo.dicModule[key]) as ModuleBase;
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
            if (!(httpContext.Items[WebInfo.Key] is WebInfo moduleInfo)) return false;
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
            if (ModuleCurrent == null) return false;
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

            IView rsView = null;
            if (((isModuleAuth && !isMethodNotAuth) || isMethodAuth)&&!ModuleCurrent.IsAuth) {
                rsView = ModuleCurrent.GoToAuth().As<RedirectView>();
            }
            else
            {
                #region Bind Param action
                List<object> paraValues = new List<object>();
                foreach (var param in methodFunction.GetParameters())
                {
                    BindFormAttribute attr = null;
                    if ((attr = param.GetAttribute<BindFormAttribute>()) != null)
                    {
                        paraValues.Add(httpContext.GetObjectValueByForm(param.ParameterType, string.IsNullOrEmpty(attr.FromName) ? param.Name : attr.FromName));
                    }
                    else
                    {
                        var attr1 = param.GetAttribute<BindQueryAttribute>();
                        paraValues.Add(httpContext.GetObjectValueByQuery(param.ParameterType, (attr1 == null || string.IsNullOrEmpty(attr1.FromName)) ? param.Name : attr1.FromName));
                    }
                }
                #endregion
                var rsFN = methodFunction.Invoke(ModuleCurrent, paraValues.ToArray());
                if (rsFN is Task)
                {
                    rsView = await (Task<Common.IView>)rsFN;
                }
                else
                {
                    rsView = (Common.IView)rsFN;
                }
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
                    if (!WebInfo.dicModule.ContainsKey(typeThemeString))
                        return false;
                    var theme = httpContext.GetService<ThemeBase>(WebInfo.dicModule[typeThemeString]);

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
