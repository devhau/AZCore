using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Location
{
    public class UpdateLocation : PageUpdate<UserService,UserModel>
    {
        public UpdateLocation(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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
