using Microsoft.AspNetCore.Http;

namespace AZWeb.Utilities
{
    public class AZAuthStore
    {
        HttpContext HttpContext;
        public AZAuthStore(IHttpContextAccessor httpContext) : this(httpContext.HttpContext)
        {
        }
        public AZAuthStore(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }
}
