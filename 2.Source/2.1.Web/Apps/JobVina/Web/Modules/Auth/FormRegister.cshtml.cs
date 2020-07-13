using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Auth
{
    public class FormRegister : PageModule
    {
        public FormRegister(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.IsTheme = false;
            return View();
        }
    }
}
