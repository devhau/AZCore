using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Errors
{
    public class NotFoundModule: PageModule
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
