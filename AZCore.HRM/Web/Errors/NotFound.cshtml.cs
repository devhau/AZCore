using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZCore.HRM.Web.Errors
{
    public class NotFound : ModuleBase
    {
        public NotFound(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get() {
            this.Title = "404 - Không tìm thấy trang";
            return View();
        }
    }
}
