using AZSocial.Shoppe;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.Social
{

    public class FormSocial : PageModule
    {
        Shopee shopee = new Shopee();
        public FormSocial(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public IView Get() {
            this.Title = "Thiết lập mạng xã hội";
            return View();
        }
        public IView GetConnectDone()
        {
            return Json("");
        }
        public IView GetConnect(string type) {


            return GoToRedirect(shopee.GetLinkAuth("https://k.localhost:5001/hoan-thanh-ket-noi-social.az"));
        }
    }
}
