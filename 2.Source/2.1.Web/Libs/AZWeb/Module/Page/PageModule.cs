using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Net;
using System.Security.Claims;

namespace AZWeb.Module.Page
{
    public class PageModule : PageBase
    {
        #region --- Init ----
        public bool IsTheme { get; set; } = true;
        public string LayoutTheme { get; set; } = "";
        public string ThemeName { get; set; }
        public string Title { get => Html.Title; set => Html.Title = value; }
        public string Description { get => Html.Description; set => Html.Description = value; }
        public string Keyword { get => Html.Keyword; set => Html.Keyword = value; }
        public HtmlContent Html { get => this.HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
        RenderView renderView { get; }
       
        public void AddMeta(string name, string content)
        {
            this.Html.AddMeta(name, content);
        }
        public void AddJS(string Code, string link, string CDN)
        {
            this.Html.AddJS(Code, link, CDN);
        }
        public void AddCSS(string Code, string link, string CDN)
        {
            this.Html.AddCSS(Code, link, CDN);
        }
        #endregion

        public PageModule(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            if (this.HttpContext.Items[AZWebConstant.Html] == null) {
                this.HttpContext.Items[AZWebConstant.Html] = new HtmlContent();
            }           
            this.renderView = this.HttpContext.GetRenderView();
        }

        #region --- Auth ---
      
        public async System.Threading.Tasks.Task LoginAsync(UserInfo user, bool rememberMe = false)
        {
            var claimIdenties = new ClaimsIdentity(user.CreateClaim(), IdentityConstants.ApplicationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdenties);

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                   claimPrincipal,
                 new AuthenticationProperties() { IsPersistent=rememberMe});
        }
        public async System.Threading.Tasks.Task LogoutAsync() {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);
        }
        #endregion

        #region --- View ---
        public virtual IView View() {
            return View(this);
        }
        public virtual IView View(object model)
        {
            return View("", model);
        }
        public virtual IView View(string viewName)
        {
            return View(viewName, this);
        }
        public virtual IView View(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = this.GetType().Name;
            return new HtmlView()
            {
                Model=model,
                ViewName= viewName,
                Path= string.Format("~/{0}",this.GetPathMoule()),
                Module=this,
            };
        }
        #endregion

        #region --- File ----
        public virtual IView DownloadFile(Stream file, string fileName) {
            return DownloadFile(file, fileName,DownloadFileView.Text);
        }
        public virtual IView DownloadFile(Stream file,string fileName, string contentType) {
            return new DownloadFileView() { File=file,ContentType= contentType ,Name= fileName,Module=this};
        }
        #endregion


        [OnlyAjax]
        public IView PostUpload() {
            return Json("");
        }
        public virtual IHtmlContent ViewChild(string viewName, object model=null)
        {
            return this.renderView.GetContentHtmlFromView(new HtmlView()
            {
                Model = model,
                ViewName = viewName,
                Path = this.GetPathMoule(),
                Module = this
            }).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
