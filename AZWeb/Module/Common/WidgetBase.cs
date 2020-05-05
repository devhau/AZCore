using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public class WidgetBase : ModuleBase
    {
        RenderView renderView { get; }
        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.renderView = new RenderView(this.HttpContext);
        }
        public async Task<IHtmlContent> GetView() {
            return await renderView.GetContentHtmlFromView(View() as HtmlView);
        }
        public IView PostData() {
            return null;
        }
        #region --- View ---
        public virtual IView View()
        {
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
                Model = model,
                ViewName = viewName,
                Path = string.Format("~/{0}", this.GetPathMoule()),
                Module = this,
            };
        }
        #endregion
    }
}
