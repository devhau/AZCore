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
        UserService userService;
        public FormLogin(IHttpContextAccessor httpContext, UserService _userService) : base(httpContext)
        {
            this.userService = _userService;
        }
        protected override void IntData()
        {
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
        
        public IView Post(string azemail,string azpassword) {
            var usr = this.userService.GetEmailOrUsername(azemail);
            if(usr.HasPassword(azpassword)) {
                this.Login(usr.CopyTo<UserInfo>());
             return  this.GoToHome();
            }
            // Login Thanh cong;
            return View();
        }
    }
}
