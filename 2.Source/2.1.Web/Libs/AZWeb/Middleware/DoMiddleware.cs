using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Middleware
{
    public abstract class DoMiddlewareBase
    {
        private readonly RequestDelegate _next;

        public DoMiddlewareBase(
            RequestDelegate next)
        {
            _next = next;
        }
        protected abstract Task<bool> DoMiddleware(HttpContext httpContext);
        public async Task Invoke(HttpContext httpContext)
        {
            if(!await DoMiddleware(httpContext))
            {
                await _next(httpContext);
            }

        }
    }
}
