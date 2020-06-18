
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
            this.LayoutTheme = "Fullscreen";
            return View();
        }
    }
}
