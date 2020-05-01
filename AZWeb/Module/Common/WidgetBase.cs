using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class WidgetBase : ModuleBase
    {
        RenderView renderView { get; }
        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.renderView = new RenderView(this.HttpContext);
        }
    }
}
