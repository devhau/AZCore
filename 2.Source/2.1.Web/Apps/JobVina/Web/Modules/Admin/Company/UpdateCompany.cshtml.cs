using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Company
{
    public class UpdateCompany : PageUpdate<UserService,UserModel>
    {
        public UpdateCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            
        }
        protected override void AfterGet()
        {
            if (this.IsNew)
            {
                this.Title = "Thêm mới công ty mới";
            }
            else
                this.Title = "Cập nhật công ty: " + this.Data.FullName;
        }
    }
}
