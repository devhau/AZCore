using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Module
{
    public abstract class ThemeBase:ModuleBase
    {
        public ThemeBase(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        
        public string GetHtml() {
            IntData();
            return View().Html;
        }
        public override void RenderSite()
        {
            httpContext.Response.WriteAsync(this.GetHtml());
        }
    }

}
