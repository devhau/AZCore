using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Themes.JobHome
{
    public class LayoutTheme: ThemeBase
    {
        public LayoutTheme(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
