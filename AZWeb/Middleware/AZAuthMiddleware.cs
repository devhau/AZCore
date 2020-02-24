using AZWeb.Configs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Middleware
{
    public class AZAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPagesConfig _page;

        public AZAuthMiddleware(
            RequestDelegate next, IPagesConfig page)
        {
            _next = next;
            _page = page;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            

        }
    }
}
