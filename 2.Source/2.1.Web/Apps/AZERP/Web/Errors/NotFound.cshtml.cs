
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFound : PageModule
    {
        public NotFound(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            this.Title = "404 - not found page";
            this.LayoutTheme = "Fullscreen";
            return View();
        }
    }
}
