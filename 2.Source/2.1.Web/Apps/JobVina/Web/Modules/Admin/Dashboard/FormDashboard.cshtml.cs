using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Dashboard
{
    public class FormDashboard : PageAdmin
    {
        public FormDashboard(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.Title = "Bảng điều khiển cá nhân";
            return View();
        }
    }
}
