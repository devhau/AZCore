using AZWeb.Module.Common;
using AZWeb.Module.Page;

namespace AZERP.Web.Modules.Common.Tenant
{
    public class FormTenantRegister : PageModule
    {
        public FormTenantRegister(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView Get() {
            this.Title = "Thiết lập cửa hàng mới";
            return View();
        }
    }
}
