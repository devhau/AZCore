using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFoundModule: PageModule
    {
        public NotFoundModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            return View();
        }
    }
}
