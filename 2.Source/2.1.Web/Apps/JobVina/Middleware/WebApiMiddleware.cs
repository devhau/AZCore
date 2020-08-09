using AZCore.Extensions;
using AZWeb.Middleware;
using AZWeb.Module;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobVina.Middleware
{
    public class WebApiMiddleware : DoMiddlewareBase
    {
        static Regex regexApi = new Regex("(?:/|^)[^./]+$");
        const string pathModule = "WebApi.";
        public WebApiMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override async Task<bool> DoMiddleware(HttpContext httpContext)
        {
            await Task.CompletedTask;
            if (httpContext.Items[WebInfo.Key] == null)
            {
                if (regexApi.IsMatch(httpContext.Request.Path.Value)) {
                    Debug.WriteLine("");
                    var ModulePath = httpContext.Request.Path.Value.Replace("-", "").Replace("/",".").Trim('.');
                    int lastDot = ModulePath.LastIndexOf('.');
                    string method = ModulePath.Substring(lastDot + 1);

                    ModulePath = ModulePath.Remove(lastDot);
                    if (ModulePath.IsNullOrEmpty()){
                        return false;
                    }
                    httpContext.Items[WebInfo.Key] = new WebInfo()
                    {
                        ModulePath = string.Format("{0}{1}Controller", pathModule, ModulePath),
                        MethodName = string.Format("{0}{1}", httpContext.Request.Method, method),
                        IsAuto = true
                    };
                }
            }
            return false;
        }
    }
}
