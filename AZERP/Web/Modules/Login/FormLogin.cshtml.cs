using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Login
{
    public class FormLogin:ModuleBase
    {
        public FormLogin(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get() {
            this.Title = "Đăng nhập hệ thống";
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
            return View() ;
        }
        public IViewResult Post() {

            return View();
        }
    }
}
