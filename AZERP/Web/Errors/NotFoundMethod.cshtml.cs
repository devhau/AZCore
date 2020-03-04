using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Errors
{
    public class NotFoundMethod : ModuleBase
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
