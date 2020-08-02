using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.UserCompany
{
    public class UpdateUserCompany : PageUpdate<UserService,UserModel>
    {
        public UpdateUserCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            
        }
        protected override void AfterGet()
        {
            if (this.IsNew)
            {
                this.Title = "Thêm mới nhân viên mới";
            }
            else
                this.Title = "Cập nhật nhân viên: " + this.Data.FullName;
        }
        public override void AfterInsert(UserModel DataForm)
        {
            base.AfterInsert(DataForm);
        }
    }
}
