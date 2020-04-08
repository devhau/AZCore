using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Middleware
{
    public class AZModuleMiddleware
    {
        private readonly RequestDelegate _next;

        public AZModuleMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
             if(! await ModuleRender.RouterAsync(httpContext))
                await _next(httpContext);
        }
    }
}
