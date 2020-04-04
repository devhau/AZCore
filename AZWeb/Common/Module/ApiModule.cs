using AZWeb.Common.Module.View;
using AZWeb.Configs;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Module
{
    public class ApiModule : IModule, IUrlVirtual
    {
        public IQueryCollection UrlVirtual { get; private set; }
        public HttpContext httpContext { get; private set; }
        protected IPagesConfig PagesConfig { get; }
        public ApiModule(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext.HttpContext;
            UrlVirtual = this.httpContext.Request.Query;
            PagesConfig = this.httpContext.GetService<IPagesConfig>();
            this.httpContext.BindFormAttributeTo(this);
            this.httpContext.BindQueryAttributeTo(this);
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
