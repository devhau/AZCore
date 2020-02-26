using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Auth
{
    public class FormRegister : ModuleBase
    {
        public FormRegister(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public IViewResult Get() {
            return View();
        }
    }
}
