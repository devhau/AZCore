using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ThemeBase : ModuleBase
    {
        public ThemeBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IHtmlContent BodyContent { get; set; }
        public string LayoutTheme { get; set; }
        public HtmlView GetTheme() {
            var pathFull = this.GetType().FullName;
            var indexEnd = pathFull.LastIndexOf('.');
            var indexStart = pathFull.IndexOf(".Web.");
            var _path = pathFull.Substring(indexStart + 1, indexEnd - indexStart-1).Replace(".", "/"); ;
            return new HtmlView()
            {
                Model = this,
                Module = this,
                Path = string.Format("~/{0}", _path),
                ViewName = string.Format("{0}.cshtml", !string.IsNullOrEmpty(this.LayoutTheme) ? this.LayoutTheme : this.GetType().Name)
            };
        }
    }
}
