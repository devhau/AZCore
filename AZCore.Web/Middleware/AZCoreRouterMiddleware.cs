using AZCore.Web.Configs;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AZCore.Web.Middleware
{
    public class AZCoreRouterMiddleware
    {
        private const string PageIndex = "/PageIndex";
        private const string PageAjax= "/PageAjax";
        private readonly RequestDelegate _next;
        private readonly IPagesConfig _PagesConfig;

        public AZCoreRouterMiddleware(
            RequestDelegate next, IPagesConfig PagesConfig)
        {
            _next = next;
            _PagesConfig = PagesConfig;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            bool isReq = false;
            string query = "?";
            var pathUrl = httpContext.Request.Path;
            if (!pathUrl.HasValue|| pathUrl.Value=="/") {
                isReq = true;
                query += _PagesConfig.UrlRealDefault;
            }
            else if (pathUrl.HasValue && pathUrl.Value.EndsWith(this._PagesConfig.extenstion)) 
            {
                query += _PagesConfig.GetMatchingRewrite(pathUrl.Value);
                isReq = true;
            }
            if (isReq) {
                httpContext.Items[AZCoreWeb.KeyUrlVirtual] = string.Format("{0}{1}", pathUrl.Value, httpContext.Request.QueryString.Value);
                if (httpContext.IsAjax())
                {
                    httpContext.Request.Path = PageAjax;
                }
                else {
                    httpContext.Request.Path = PageIndex;
                }
                foreach (var key in httpContext.Request.Query.Keys) {
                    query = string.Format("{0}&{1}={2}",  query,key, httpContext.Request.Query[key]);
                }
                httpContext.Request.QueryString= new QueryString(query);
            }
            await _next(httpContext);
        }
    }
}
