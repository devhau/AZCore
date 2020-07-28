using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.UserCompany
{
    public class FormUserCompany : PageManage<UserService,UserModel, UpdateUserCompany>
    {
        public FormUserCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách nhân viên công ty";
        }
    }
}
