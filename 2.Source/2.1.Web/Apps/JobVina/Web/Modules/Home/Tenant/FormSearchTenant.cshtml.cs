using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home.Tenant
{
    public class FormSearchTenant : PageHome
    {
        public FormSearchTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.Title = "JobVINA - Thông tin tuyển dụng và đối tác cung ứng lao động uy tín";
            return View();
        }
    }
}
