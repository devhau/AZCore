using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public class ThemeBase:ModuleBase
    {
        public ThemeBase(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        protected virtual void IntData() { }
        public string GetHtml() {
            IntData();
            return View().Html;
        }
    }

}
