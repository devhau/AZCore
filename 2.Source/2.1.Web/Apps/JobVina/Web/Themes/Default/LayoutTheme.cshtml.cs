
using AZWeb.Configs;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace JobVina.Web.Themes.Default
{
    public class LayoutTheme: ThemeBase
    {
        public LayoutTheme(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
