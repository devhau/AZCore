using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule
    {
        public HttpContext HttpContext { get; }
        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
          
        }
        public void BeforeRequest() { IntData(); }
        public void AfterRequest() { }
        protected virtual void IntData(){ }
    }
}
