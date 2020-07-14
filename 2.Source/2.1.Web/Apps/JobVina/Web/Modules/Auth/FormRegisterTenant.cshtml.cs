using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Auth
{
    public class FormRegisterTenant : PageHome
    {
        public FormRegisterTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.IsTheme = false;
        }

        public IView Get()
        {
            return View();
        }
    }
}
