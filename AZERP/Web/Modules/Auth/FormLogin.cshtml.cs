using AZ.Web.Entities;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZ.Web.Modules.Auth
{
    public class FormLogin:ModuleBase
    {
        User user;
        public FormLogin(IHttpContextAccessor httpContext, User _user) : base(httpContext)
        {
            this.user = _user;
            this.user.CreateTableIfNotExitAsync().Wait();
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
        public async Task<IViewResult> Post(string azemail,string azpassword) {
            var usr = await this.user.GetEmailOrUsername(azemail);
            return View();
        }
    }
}
