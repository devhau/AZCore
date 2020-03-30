using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    [Auth]
    public class FormHome:PageModule
    {
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Bảng điều khiển";
            base.IntData();
        }
        public string id { get; set; }
        public IView Get(){
           return View();
        }
    }
}
