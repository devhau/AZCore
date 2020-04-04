using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AZWeb.Common.Module
{
    public abstract class PageModule : ApiModule
    {
        protected virtual void IntData() { }
        private static Regex regexModule = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);
        private static Regex regexError = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);
        private IHtmlView _view { get; set; }
        public string Title { get => _view.Title; set => _view.Title = value; }
        public string Html { get => _view.Html; set => _view.Html = value; }
        public bool IsTheme { get => _view.IsTheme; set => _view.IsTheme = value; }
        public string LayoutTheme { get; set; } = "LayoutTheme";
        public UserInfo User { get => this.httpContext.GeUserModule(); }
        public bool IsAuth { get => User != null; }

        protected void DoView(Action<IHtmlView> ac)
        {
            if (ac != null) ac(_view);
        }
        public override void BeforeRequest() {
            this._view = this.httpContext.GetContetModule();
            IsTheme = true;
            IntData();
        }
        public override void AfterRequest()
        {}
        public PageModule(IHttpContextAccessor httpContext):base(httpContext) {
            
        }
      
        public void Login(object User) {
            var userInfo = User.CopyTo<UserInfo>();
            this.httpContext.SetSession(AZCoreWeb.KeyAuth, userInfo);
            this.httpContext.SetCookie(AZCoreWeb.KeyAuth, userInfo, 10 * 24 * 60);
            this.httpContext.GetUser();
        }
        public void Logout() {
            this.httpContext.RemoveCookie(AZCoreWeb.KeyAuth);
            this.httpContext.RemoveCookie(AZCoreWeb.KeyAuth);
        }
        public IView RedirectToHome() {
           return Redirect("/");
        }
        public virtual IView Redirect(string location)
        {
            return new RedirectView(location);
        }
        protected IView View(){
            return View(this);
        }
        protected IView View(object mode)
        {
            return View(null, mode);
        }
        protected IView View(string viewName, object mode)
        {
            return GetView(RenderHtml(viewName, mode));
        }
        protected IView GetView(string html)
        {
            this.Html = html;
            return this._view;

        }
        protected virtual void AddMessage(string message) {

            this._view.JS.Add(new AZWeb.Configs.ContentTag() { Code = @"$(function(){alert('"+message+"');})" });
        }
        protected virtual string RenderHtml(object mode) {            
            return RenderHtml(null,mode);
        }
        protected virtual string RenderHtml(string viewName=null,object mode=null)
        {
            Type type = this.GetType();
            if (regexError.IsMatch(type.FullName))
            {
                var m = regexError.Match(type.FullName);
                if (mode == null) mode = this;
                if (string.IsNullOrEmpty(viewName)) viewName = m.Groups[2].Value;
                return this.httpContext.RenderToHtml(string.Format("~/Web/{0}", m.Groups[1].Value), viewName + ".cshtml", mode);
            }
            else if (regexModule.IsMatch(type.FullName))
            {
                var m = regexModule.Match(type.FullName);
                if (mode == null) mode = this;
                if (string.IsNullOrEmpty(viewName)) viewName = m.Groups[3].Value;
                return this.httpContext.RenderToHtml(string.Format("~/Web/{0}/{1}", m.Groups[1].Value, m.Groups[2].Value), viewName + ".cshtml", mode);
            }
            return string.Empty;
        }

        public IView File(Stream file)
        {
            return File(file, "download.txt");
        }
        public IView File(Stream file, string name) {

            return File(file, name, FileView.Text);
        }
        public IView File(Stream file, string name,string contentType) {

            return new FileView() {
                File = file,
                Name = name,
                ContentType = contentType
            };
        }
        public override string ToString()
        {
            return RenderHtml();
        }

        public virtual void RenderSite() {           
                httpContext.Response.WriteAsync(this.Html);
        }
        public virtual void RenderJson()
        {
            httpContext.Response.WriteAsync(this._view.ToJson());
        }
    }
}
