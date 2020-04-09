using AZWeb.Module.Attribute;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
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
