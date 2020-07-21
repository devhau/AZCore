using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Http;

namespace JobVina.Common
{
    [Auth]
    public abstract class PageAdmin : PageHome
    {
        public PageAdmin(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.ThemeName = "AdminLTE";
        }        
    }
}
