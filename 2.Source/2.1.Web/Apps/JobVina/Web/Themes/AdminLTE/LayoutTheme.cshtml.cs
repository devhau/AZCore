using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Themes.AdminLTE
{
    public class LayoutTheme: ThemeBase
    {
        public LayoutTheme(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
