using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;

namespace AZERP.Web.Modules.Common.Tenant
{
    public class FormTenantRegister : PageModule
    {
        public FormTenantRegister(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        [BindService]
        public EntityTransaction EntityTransaction { get; set; }
        public TenantModel TenantModel;
        public IView Get() {
            if (!this.IsAjax && !this.IsAuth)
                this.LayoutTheme = "Fullscreen";
            this.Title = "Thiết lập cửa hàng mới";
            if (this.IsAuth) {
                TenantModel = new TenantModel();
                TenantModel.Name = this.User.FullName;
                TenantModel.Email = this.User.Email;
                TenantModel.Phone = this.User.PhoneNumber;
            }
            return View();
        }
        public IView Post([BindForm]UserModel User, [BindForm]TenantModel Tenant) {
            if (User == null&&this.IsAuth)
            {
                EntityTransaction.DoTransantion<TenantService, TenantUserService>((p, p1, p2) =>
                {

                    


                });
            }
            else {

                EntityTransaction.DoTransantion<TenantService, UserService, TenantUserService>((p, p1, p2, p3) => {

                    User.FullName = Tenant.Name;
                    User.Email = Tenant.Email;
                    User.PhoneNumber = Tenant.Phone;


                });
            }
            return Json("Thành công");
        }
    }
}
