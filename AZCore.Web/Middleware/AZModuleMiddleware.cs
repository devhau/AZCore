using AZCore.Web.Common.Module;
using AZCore.Web.Configs;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZCore.Web.Middleware
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

            if (!ModuleStore.Router(httpContext)) {
                await _next(httpContext);
            }
        }
    }
}
