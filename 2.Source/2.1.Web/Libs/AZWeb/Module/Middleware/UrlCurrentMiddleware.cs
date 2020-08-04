using AZWeb.Module.Constant;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZWeb.Module.Middleware
{
    public class UrlCurrentMiddleware
    {
        private readonly RequestDelegate _next;

        public UrlCurrentMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items[AZWebConstant.KeyUrlCurrent] = string.Format("{0}{1}", httpContext.Request.Path.Value, httpContext.Request.QueryString.Value);
            await _next(httpContext);
        }
    }
}
