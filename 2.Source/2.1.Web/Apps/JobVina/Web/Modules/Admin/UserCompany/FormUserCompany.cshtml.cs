using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.UserCompany
{
    public class FormUserCompany : PageAdmin
    {
        public FormUserCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            this.Title = "Danh sách nhân viên công ty";
            return View();
        }
    }
}
