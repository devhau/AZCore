using AZ.Web.Entities;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Modules.Auth
{
    public class FormLogin:ModuleBase
    {
        UserService userService;
        public FormLogin(IHttpContextAccessor httpContext, UserService _userService, DBCreateEntities dbCreate) : base(httpContext)
        {
            dbCreate.CheckDatabase();
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
            
            return View() ;
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
            else {
                this.httpContext.Response.Redirect("/dang-ky.az");
            }
            // Login Thanh cong;
            return View();
        }
    }
}
