using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFoundMethod : PageModule
    {
        public NotFoundMethod(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            this.Title = "Không tìm thấy Method";
            return View();
        }
    }
}
