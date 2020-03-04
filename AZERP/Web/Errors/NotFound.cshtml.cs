using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Errors
{
    public class NotFound : ModuleBase
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
