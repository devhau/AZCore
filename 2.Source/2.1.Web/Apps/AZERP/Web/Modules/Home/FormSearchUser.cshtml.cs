using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormSearchUser : PageModule
    {

        public FormSearchUser(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        public IView Get()
        {
            this.Title = "Tìm lao động tại các khu công nghiệp";
            return View();
        }
    }
}
