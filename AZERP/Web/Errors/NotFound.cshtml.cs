using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFound : PageModule
    {
        public NotFound(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            this.Title = "404 - Không tìm thấy trang";
            return View();
        }
    }
}
