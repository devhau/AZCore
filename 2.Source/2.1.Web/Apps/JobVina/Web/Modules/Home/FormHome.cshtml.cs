using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home
{
    public class FormHome : PageModule
    {
        public FormHome(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            return View();
        }
    }
}
