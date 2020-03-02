using AZWeb.Common.Module;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZWeb.Middleware
{
    public class AZWebMiddleware
    {
        private readonly RequestDelegate _next;

        public AZWebMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            if (!ModuleStore.Router(httpContext)) {
                await _next(httpContext);
            }
        }
    }
}
