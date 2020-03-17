using AZCore.Database;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Manager
{
    public class UpdateModule<TService, TModel> : PageModule 
        where TModel: IEntityModel
        where TService:EntityService<TService,TModel>
    {

        protected TService Service;
        protected TModel Data;
        public UpdateModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.httpContext.GetService<TService>();
        }
        public virtual IView Get(object Id) {
            if (Id != null) {
                this.Data = this.Service.GetById(Id);
            }
            return View();
        }
        public virtual IView Post(object Id)
        {
            if (Id != null)
            {
            }
            return View();
        }
    }
}
