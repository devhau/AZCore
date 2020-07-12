using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Auth
{
    public class FormLogin : PageModule
    {
        public FormLogin(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public void Get()
        {
        }
    }
}
