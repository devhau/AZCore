using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.PowerChat
{
    public class FormPowerChat : PageModule
    {
        public FormPowerChat(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView Get()
        {
            this.Title = "Thiết lập module";
            return View();
        }
    }
}
