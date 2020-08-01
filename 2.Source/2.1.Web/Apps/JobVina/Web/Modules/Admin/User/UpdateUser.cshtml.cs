using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.User
{
    public class UpdateUser : PageUpdate<UserService,UserModel>
    {
        public UpdateUser(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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
    }
}
