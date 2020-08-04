using AZWeb.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Middleware
{
    public class ModuleWebMiddleware
    {
        private readonly RequestDelegate _next;

        public ModuleWebMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (!await ModuleWebRender.RouterAsync(httpContext))
                await _next(httpContext);
        }
    }
}
