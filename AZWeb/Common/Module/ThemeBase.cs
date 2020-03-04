using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Module
{
    public abstract class ThemeBase:ModuleBase
    {
        public ThemeBase(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            base.IntData();
        }
        public string GetHtml() {
            IntData();
            return View().Html;
        }
        public override void RenderSite()
        {
            this.HtmlResult.DoResult((mdo) =>
            {
                if (!httpContext.IsAjax() && PagesConfig != null)
                {
                    if (PagesConfig.Head != null)
                    {
                        mdo.CSS.InsertRange(0, PagesConfig.Head.Stypes);
                        mdo.JS.InsertRange(0, PagesConfig.Head.Scripts);
                    }
                }
            });
            httpContext.Response.WriteAsync(this.GetHtml());
        }
    }
}
