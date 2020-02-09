using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Utilities
{
    public class AZCoreWeb
    {
        public const string KeyHtmlModule = "AZHtmlModule";

        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }
        private HttpContext HttpContext { get; }
        public AZCoreWeb(HttpContext httpContext) {
            HttpContext = httpContext;
            BindQueryToThis();
        }
        private void BindQueryToThis() {
            this.HttpContext.BindRequestTo(this);
        }
        public IModuleResult GetResult()
        {
            return null;
        }

    }
}
