using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Errors
{
    public class NotFoundModule: ModuleBase
    {
        public NotFoundModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IView Get() {
            this.Title = "Không tìm thấy module";
            return View();
        }
    }
}
