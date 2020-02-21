using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZCore.HRM.Web.Modules.Login
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
    }
}
