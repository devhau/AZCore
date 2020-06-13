using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormHome:PageModule
    {

        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        protected override void IntData()
        {
            this.Title = "Trang chủ - thông tin tuyển dụng JobF";
            base.IntData();
        }
        public IView Get(){
           return View();
        }
    }
}
