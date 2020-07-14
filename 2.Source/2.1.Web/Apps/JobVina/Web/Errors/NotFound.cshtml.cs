using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Errors
{
    public class NotFound : PageModule
    {
        public NotFound(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.IsTheme = false;
            return View();
        }
    }
}
