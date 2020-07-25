using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Company
{
    public class FormCompany : PageManage<UserService,UserModel, UpdateCompany>
    {
        public FormCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách công ty";
        }
    }
}
