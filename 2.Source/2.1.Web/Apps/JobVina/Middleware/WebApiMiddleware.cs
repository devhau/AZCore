using AZWeb.Middleware;
using AZWeb.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobVina.Middleware
{
    public class WebApiMiddleware : DoMiddlewareBase
    {
        public WebApiMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override async Task<bool> DoMiddleware(HttpContext httpContext)
        {
            await Task.CompletedTask;
            if (httpContext.Items[ModuleWebInfo.Key] == null)
            {

            }
            return false;
        }
    }
}
