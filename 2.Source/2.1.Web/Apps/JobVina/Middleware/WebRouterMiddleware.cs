using AZWeb.Middleware;
using AZWeb.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace JobVina.Middleware
{
    public class WebRouterMiddleware : DoMiddlewareBase
    {
        public WebRouterMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override async Task<bool> DoMiddleware(HttpContext httpContext)
        {
            if (httpContext.Items[ModuleWebInfo.Key] == null)
            {
                if(ModuleWebInfo.Rewrites!=null&& ModuleWebInfo.Rewrites.Count > 0)
                {
                    var urlPath = (httpContext.Request.Path);
                    if (urlPath == "/")
                    {
                        httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                        {
                            ModulePath = "Web.Modules.Home.FormHome",
                            MethodName = "Get"
                        };
                    }
                    else if(urlPath.Value.EndsWith(".az"))
                    {
                        foreach (var item in ModuleWebInfo.Rewrites)
                        {
                            var RegexPath = new Regex(string.Format("/{0}", item.Key));
                            if (RegexPath.IsMatch(urlPath))
                            {
                                var rs = RegexPath.Replace(urlPath, item.Value);



                                break;
                            }
                        }
                    }
                   
                }
            }
            await Task.CompletedTask;
            return false;
        }
    }
}
