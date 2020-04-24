using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZWeb.Module.Middleware
{
    public class ModuleMiddleware
    {
        private readonly RequestDelegate _next;

        public ModuleMiddleware(
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
