using AZCore.Extensions;
using AZCore.Identity;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Modules.Common.Auth
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
            this.LayoutTheme = "Fullscreen";
        }

        public  IView Get()
        {
            return View();
        }
        public async Task<IView> GetLogout() {
            await this.LogoutAsync();
            return GoToHome();
        }
        
        public async  Task<IView> Post([BindForm]string azemail, [BindForm]string azpassword, [BindForm]bool azremember) {
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
                    var ulogin = usr.CopyTo<UserInfo>();
                   await this.LoginAsync(ulogin, azremember);
                    return this.GoToHome();
                }
            }
            Error = "Tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}
