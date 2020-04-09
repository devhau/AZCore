using AZWeb.Module.Common;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AZWeb.Module.Page
{
    public class PageModule : ModuleBase
    {
        public bool IsTheme { get; set; } = true;
        public string LayoutTheme { get; set; } = "";
        public string Title { get => Html.Title; set => Html.Title = value; }
        public string Description { get => Html.Description; set => Html.Description = value; }
        public string Keyword { get => Html.Keyword; set => Html.Keyword = value; }
        public HtmlContent Html { get => this.HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
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
            var pathFull = this.GetType().FullName;
            var indexEnd= pathFull.LastIndexOf('.');
            if(string.IsNullOrEmpty(viewName))
                viewName = pathFull.Substring(indexEnd+1);
            var indexStart = pathFull.IndexOf(".Web.");
            var _path = pathFull.Substring(indexStart + 1, indexEnd - indexStart-1).Replace(".", "/"); ;
            return new HtmlView()
            {
                Model=model,
                ViewName= viewName,
                Path= string.Format("~/{0}",_path),
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
            return Json(Message, null, 200);
        }
        public virtual IView Json(string Message, int status)
        {
            return Json(Message, null, status);
        }
        public virtual IView Json(string Message, object data) {
            return Json(Message,data, 200);        
        }
        public virtual IView Json(string Message, object data,int status) {         
            return new JsonView() { Module=this,Data=data,StatusCode=status, Message=Message };
        }
    }
}
