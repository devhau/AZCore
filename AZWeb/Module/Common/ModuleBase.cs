using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule, IUrlVirtual
    {
        public IQueryCollection UrlVirtual { get; }
        public HttpContext HttpContext { get; }
        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            UrlVirtual = HttpContext.Request.Query;

            this.HttpContext.BindFormAttributeTo(this);
            this.HttpContext.BindQueryAttributeTo(this);

        }
        public virtual void BeforeRequest() { IntData(); }
        public virtual void AfterRequest() { }
        protected virtual void IntData(){ }
    }
}
