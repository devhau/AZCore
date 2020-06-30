using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormSearchHome : PageModule
    {

        public FormSearchHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        public IView Get()
        {
            this.Title = "Tìm nhà trọ tại các khu công nghiệp";
            return View();
        }
    }
}
