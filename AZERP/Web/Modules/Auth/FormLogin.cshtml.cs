using AZERP.Data.Entities;
using AZWeb.Extensions;
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
            
        }

        public  IView Get(object[] Id)
        {
            return View();
        }
        public IView GetLogout() {
            return View();
        }
        
        public IView Post(string azemail,string azpassword) {
            var usr = this.userService.GetEmailOrUsername(azemail);
           
            // Login Thanh cong;
            return View();
        }
    }
}
