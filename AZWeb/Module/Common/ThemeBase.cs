using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public class ThemeBase : ModuleBase
    {
        public UserInfo User { get; private set; }
        public bool IsAuth { get => User != null; }
        RenderView renderView { get; }
        public ThemeBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.User = this.HttpContext.GetSession<UserInfo>(AZWebConstant.SessionUser);
            if (this.User == null)
            {
                this.User = this.HttpContext.GetCookie<UserInfo>(AZWebConstant.CookieUser);
                if (this.User != null)
                {
                    this.HttpContext.SetSession(AZWebConstant.SessionUser, this.User);
                }
            }
            this.renderView = new RenderView(this.HttpContext);
        }
        public IHtmlContent BodyContent { get; set; }
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
        public string LayoutTheme { get; set; }
        public virtual IHtmlContent ViewChild(string viewName)
        {
            return  this.ViewChild(viewName, this);
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
        public HtmlView GetTheme() {
            
            return new HtmlView()
            {
                Model = this,
                Module = this,
                Path = string.Format("~/{0}", this.GetPathMoule()),
                ViewName = string.Format("{0}", !string.IsNullOrEmpty(this.LayoutTheme) ?  string.Format("Layout{0}", this.LayoutTheme) : this.GetType().Name)
            };
        }
    }
}
