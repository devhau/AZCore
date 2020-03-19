using AZWeb.Common.Module.View;
using AZWeb.Configs;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Module
{
    public class ApiModule : IModule
    {
        public HttpContext httpContext { get; private set; }
        protected IPagesConfig PagesConfig { get; }
        public ApiModule(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext.HttpContext;
            PagesConfig = this.httpContext.GetService<IPagesConfig>();
        }
        public virtual void BeforeRequest(){}
        public virtual void AfterRequest(){ }
        public IView Json(object Data, int StatusCode = 200)
        {
            return new JsonView() { Data = Data, StatusCode = StatusCode};
        }
        public IView Json(string Message, int StatusCode = 404)
        {
            return new JsonView() { Message = Message, StatusCode = StatusCode};
        }
        public IView Json(object Data, string Message, int StatusCode = 200)
        {
            return new JsonView() { Data = Data, Message = Message, StatusCode = StatusCode };
        }

    }
}
