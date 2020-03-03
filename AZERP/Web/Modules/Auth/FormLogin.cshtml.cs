using AZ.Web.Entities;
using AZCore.Database;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Modules.Auth
{
    public class FormLogin:ModuleBase
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

            this.HtmlResult.DoResult((mdo) =>
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

        public  IViewResult Get(object[] Id)
        {
            var item = this.httpContext.GetSession<UserModel>(AZCoreWeb.KeyAuth);
            if (item == null) {

                item= this.httpContext.GetCookie<UserModel>(AZCoreWeb.KeyAuth);
            }
            return View();
        }
        public IViewResult GetLogout() {
            this.Title = "Đăng Xuất hệ thống thành công";
            return View();
        }
        
        public IViewResult Post(string azemail,string azpassword) {
            var usr = this.userService.GetEmailOrUsername(azemail);
            if (usr == null)
            {
                this.AddMessage("Không tìm thấy tài khoản");
            }
            else if (!this.userService.HasPassword(usr, azpassword))
            {
                this.AddMessage("Mật khẩu không chính xác");
            }
            else
            {
                usr.Password = "";
                usr.Salt="";
                this.httpContext.SetSession(AZCoreWeb.KeyAuth, usr);
                this.httpContext.SetCookie(AZCoreWeb.KeyAuth, usr,10*24*60);
                this.AddMessage("Đăng nhập thành công");
            }
            // Login Thanh cong;
            return View();
        }
    }
}
