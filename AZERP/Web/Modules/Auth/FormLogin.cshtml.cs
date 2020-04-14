using AZCore.Extensions;
using AZCore.Identity;
using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Auth
{
    public class FormLogin:PageModule
    {
        public string Error { get; set; }
        UserService userService;
        public FormLogin(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
            this.Title = "Đăng nhập hệ thống";
            this.IsTheme = false;
        }

        public  IView Get()
        {
            return View();
        }
        public IView GetLogout() {
            this.Logout();
            return GoToHome();
        }
        
        public IView Post(string azemail,string azpassword,bool azremember) {
            var usr = this.userService.GetEmailOrUsername(azemail);
            if (usr != null) {
                if (usr.HasPassword(azpassword))      
                {
                    if (usr.Status == AZCore.Database.EntityStatus.NoActive|| usr.Status == null) {

                        Error = "Tài khoản chưa được kích hoạt";
                        return View();
                    }
                    if (usr.Status == AZCore.Database.EntityStatus.Block)
                    {
                        Error = "Tài khoản đã bị khóa";
                        return View();
                    }
                    this.Login(usr.CopyTo<UserInfo>(), azremember);
                    return this.GoToHome();
                }
            }
            Error = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}
