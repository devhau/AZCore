using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.Module
{
    public class FormModule : PageModule
    {
        public FormModule(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView Get()
        {
            this.Title = "Thiết lập module";
            return View();
        }
    }
}
