using AZWeb.Module.Common;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Page
{
    public class PageModule : ModuleBase
    {
        public bool IsTheme { get; set; } = true;
        public string LayoutTheme { get; set; } = "";
        public PageModule(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
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
                ViewName= string.Format("{0}.cshtml",viewName),
                Path= string.Format("~/{0}",_path),
                Module=this,

            };
        }
    }
}
