using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Module
{
    public class ApiModule : IModule
    {
        public HttpContext httpContext { get; private set; }
        public ApiModule(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext.HttpContext;
        }
        public IView Json(object Data, int StatusCode = 200)
        {
            return new JsonView() { Data = Data, StatusCode = StatusCode, Module = this };
        }
        public IView Json(string Message, int StatusCode = 404)
        {
            return new JsonView() { Message = Message, StatusCode = StatusCode, Module = this };
        }
    }
}
