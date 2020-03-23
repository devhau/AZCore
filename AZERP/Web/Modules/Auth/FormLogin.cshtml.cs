using AZ.Web.Entities;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Auth
{
    public class FormLogin:PageModule
    {
        UserService userService;
        public FormLogin(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Đăng nhập hệ thống:";
            this.IsTheme = false;

            this.DoView((mdo) =>
            {
                if (!httpContext.IsAjax() && PagesConfig != null)
                {
                    if (PagesConfig.Head != null)
                    {
                        mdo.CSS.InsertRange(0, PagesConfig.Head.Stypes);
                        mdo.JS.InsertRange(0, PagesConfig.Head.Scripts);
                    }
                }
            });
        }

        public  IView Get(object[] Id)
        {
            return View();
        }
        public IView GetLogout() {
            this.Title = "Đăng Xuất hệ thống thành công";
            return View();
        }
        
        public IView Post(string azemail,string azpassword) {
            var usr = this.userService.GetEmailOrUsername(azemail);
            if (usr == null)
            {
                this.AddMessage("Không tìm thấy tài khoản");
            }
            else if (!usr.HasPassword(azpassword))
            {
                this.AddMessage("Mật khẩu không chính xác");
            }
            else
            {
                this.Login(usr);
             return   this.RedirectToHome();
            }
            // Login Thanh cong;
            return View();
        }
    }
}
