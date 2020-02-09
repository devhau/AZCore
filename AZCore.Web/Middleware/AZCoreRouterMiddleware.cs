using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AZCore.Web.Middleware
{
   public class AZCoreRouterMiddleware
    {
        private readonly RequestDelegate _next;

        public AZCoreRouterMiddleware(
            RequestDelegate next)
        {
            _next = next;           
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
