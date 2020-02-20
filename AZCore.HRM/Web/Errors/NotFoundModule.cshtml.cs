using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZCore.HRM.Web.Errors
{
    public class NotFoundModule: ModuleBase
    {
        public NotFoundModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get() {
            this.Title = "Không tìm thấy module";
            return View();
        }
    }
}
