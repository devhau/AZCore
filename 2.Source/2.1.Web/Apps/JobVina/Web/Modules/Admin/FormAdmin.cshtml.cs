using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin
{
    public class FormAdmin : PageAdmin
    {
        public FormAdmin(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            return GoToRedirect("/admin/dashboard.az");
        }
    }
}
