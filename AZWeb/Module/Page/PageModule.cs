using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Common;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;

namespace AZWeb.Module.Page
{
    public class PageModule : ModuleBase
    {   
        public UserInfo User { get; private set; }
        public bool IsAuth { get => User != null; }
        public bool IsTheme { get; set; } = true;
        public string LayoutTheme { get; set; } = "";
        public string Title { get => Html.Title; set => Html.Title = value; }
        public string Description { get => Html.Description; set => Html.Description = value; }
        public string Keyword { get => Html.Keyword; set => Html.Keyword = value; }
        public HtmlContent Html { get => this.HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
        RenderView renderView { get; }
        public bool HasPermission(string permissionCode) {
            return User != null && User.HasPermission(permissionCode);
        }
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
        public PageModule(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            if (this.HttpContext.Items[AZWebConstant.Html] == null) {
                this.HttpContext.Items[AZWebConstant.Html] = new HtmlContent();
            }
            this.User = this.HttpContext.GetSession<UserInfo>(AZWebConstant.SessionUser);
            if (this.User == null)
            {
                this.User = this.HttpContext.GetCookie<UserInfo>(AZWebConstant.CookieUser);
                if (this.User != null) {
                    this.HttpContext.SetSession(AZWebConstant.SessionUser,this.User);
                }
            }
            this.renderView = new RenderView(this.HttpContext);
        }
        public virtual IView GoToAuth() {
            return GoToRedirect("/dang-nhap.az");
        }
        public virtual IView GoToHome() {
            return GoToRedirect("/");
        }
        public virtual IView GoToRedirect(string url) {
            return new RedirectView() {Module=this,RedirectToUrl=url };
        }

        public void Login(UserInfo user, bool rememberMe = false)
        {
            this.User = user;
            this.HttpContext.SetSession(AZWebConstant.SessionUser, this.User);
            if (rememberMe)
                this.HttpContext.SetCookie(AZWebConstant.CookieUser, this.User,10*360*24*60); // nhớ tới 10 năm khi bạn già thì vẫn nhớ tới bạn
        }
        public void Logout() {
            this.HttpContext.Response.Cookies.RemoveCookie(AZWebConstant.CookieUser);
            this.HttpContext.Session.Clear();
        }
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
      
        public virtual IView DownloadFile(Stream file, string fileName) {
            return DownloadFile(file, fileName,DownloadFileView.Text);
        }
        public virtual IView DownloadFile(Stream file,string fileName, string contentType) {
            return new DownloadFileView() { File=file,ContentType= contentType ,Name= fileName,Module=this};
        }
        public virtual IView Json(string Message)
        {
            return Json(Message, string.Empty, HttpStatusCode.OK);
        }
        public virtual IView Json(string Message, HttpStatusCode status)
        {
            return Json(Message, string.Empty, status);
        }
        public virtual IView Json(string Message, object data) {
            return Json(Message,data, HttpStatusCode.OK);        
        }
        public virtual IView Json(string Message, object data, HttpStatusCode status) {         
            return new JsonView() { Module=this,Data=data,StatusCode=status, Message=Message };
        }
        public virtual IHtmlContent ViewChild(string viewName, object model)
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
