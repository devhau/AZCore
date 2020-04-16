using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule, IUrlVirtual
    {
        public QueryString UrlVirtual { get; }
        public HttpContext HttpContext { get; }
        public bool IsAjax { get; }
        private string path { get; }
        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            this.IsAjax = HttpContext.IsAjax();
            UrlVirtual = HttpContext.Request.QueryString;

            this.HttpContext.BindFormAttributeTo(this);
            this.HttpContext.BindQueryAttributeTo(this); var pathFull = this.GetType().FullName;
            var indexEnd = pathFull.LastIndexOf('.');
            var indexStart = pathFull.IndexOf(".Web.");
            path = pathFull.Substring(indexStart + 1, indexEnd - indexStart - 1).Replace(".", "/"); 
          
        }
        public virtual void BeforeRequest() { IntData(); }
        public virtual void AfterRequest() { }
        protected virtual void IntData(){ }
        protected virtual string GetPathMoule() {
            return path;
        }
    }
}
