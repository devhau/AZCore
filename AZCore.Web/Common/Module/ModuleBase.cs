using AZCore.Extensions;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        public IModuleResult View(){
            return View(this);
        }
        public IModuleResult View(object mode)
        {
            return View(null, mode);
        }
        public IModuleResult View(string viewName, object mode)
        {
            return new ModuleResult()
            {
                Html = RenderHtml(viewName, mode)
            };
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
        internal virtual IModuleResult GetResult() {
            var methodFunction = this.GetType().GetMethod(string.Format("{0}{1}", this.httpContext.Request.Method.ToUpperFirstChart(), this.h.ToUpperFirstChart()));
         var paras=   methodFunction.GetParameters();
            List<object> paraValues = new List<object>();
            foreach (var item in paras) {
                if (false && this.httpContext.Request.Query.ContainsKey(item.Name)) {
                    paraValues.Add(Convert.ChangeType(this.httpContext.Request.Query[item.Name], item.ParameterType));
                } else {
                    if(item.HasDefaultValue)
                    paraValues.Add(item.RawDefaultValue);
                    else
                        paraValues.Add(null);
                }
            }
           var rsObj= methodFunction.Invoke(this,paraValues.ToArray());
            if (rsObj != null) {
                if (rsObj.GetType() == typeof(ModuleResult)) {
                    return (ModuleResult)rsObj;
                }
                else
                {
                    return new ModuleResult()
                    {
                        Html = rsObj.ToString()
                    };
                }
            }
            return new ModuleResult()
            {
                
            };
        }

        public override string ToString()
        {
            return RenderHtml();
        }
    }
}
