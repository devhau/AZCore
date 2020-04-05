using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Candidate
{
    [Auth]
    public class FormSale : PageModule
    {
        public FormSale(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Chăm sóc ứng viên";
            base.IntData();
        }
        public string id { get; set; }
        public IView Get(){
           return View();
        }
    }
}
