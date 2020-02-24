using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Login
{
    public class FormLogout : ModuleBase
    {
        public FormLogout(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get()
        {
            return View();
        }
    }
}
