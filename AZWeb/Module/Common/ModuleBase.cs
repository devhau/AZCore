using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule, IUrlVirtual
    {
        public QueryString UrlVirtual { get; }
        public HttpContext HttpContext { get; }
        public bool IsAjax { get; }
        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            this.IsAjax = HttpContext.IsAjax();
            UrlVirtual = HttpContext.Request.QueryString;

            this.HttpContext.BindFormAttributeTo(this);
            this.HttpContext.BindQueryAttributeTo(this); 

        }
        public virtual void BeforeRequest() { IntData(); }
        public virtual void AfterRequest() { }
        protected virtual void IntData(){ }
    }
}
