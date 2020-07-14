using AZWeb.Extensions;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace JobVina.Common
{
    public class PageHome : PageModule
    {
        public PageHome(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.ThemeName = "JobHome";
        }       
    }
}
