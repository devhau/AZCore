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
            this.Title = "JobVINA - Thông tin tuyển dụng và đối tác cung ứng lao động uy tín";
            return View();
        }
    }
}
