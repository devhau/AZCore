
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFoundMethod : PageModule
    {
        public NotFoundMethod(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            return View();
        }
    }
}
