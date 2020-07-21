using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home
{
    public class FormHome : PageHome
    {
        public FormHome(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.Title = "JobVINA";
            return View();
        }
    }
}
