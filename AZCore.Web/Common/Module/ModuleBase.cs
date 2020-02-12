using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace AZCore.Web.Common.Module
{
    public class ModuleBase : IModule
    {
        public string m { get; set; }
        public string v { get; set; }
        public string h { get; set; }
        private static Regex regexModule = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+).([A-Za-z0-9]+)", RegexOptions.IgnoreCase);

        public HttpContext httpContext { get; private set; }

        public ModuleBase InitModule(HttpContext httpContext)
        {
            this.httpContext = httpContext;
            this.httpContext.BindRequestTo(this);
            return this;
        }
        public virtual string RenderHtml(object mode) {            
            return RenderHtml(null,mode);
        }
        public virtual string RenderHtml(string viewName=null,object mode=null)
        {
            Type type = this.GetType();
            if (regexModule.IsMatch(type.FullName))
            {
                var m = regexModule.Match(type.FullName);
                if (mode == null) mode = this;
                if (string.IsNullOrEmpty(viewName)) viewName = m.Groups[3].Value;
                return this.httpContext.RenderToHtml(string.Format("~/Web/{0}/{1}", m.Groups[1].Value, m.Groups[2].Value), viewName + ".cshtml", mode);
            }
            return string.Empty;
        }
        public virtual IModuleResult GetResult() {

            return new ModuleResult()
            {
                Html = this.ToString()
            };
        }

        public override string ToString()
        {
            return RenderHtml();
        }
    }
}
