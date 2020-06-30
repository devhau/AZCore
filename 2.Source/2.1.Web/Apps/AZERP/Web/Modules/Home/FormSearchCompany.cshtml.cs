using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormSearchCompany : PageModule
    {

        public FormSearchCompany(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        public IView Get()
        {
            this.Title = "Tìm kiếm thông tin công ty tuyển dụng";
            return View();
        }
    }
}
