using AZCore.Database;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZWeb.Common.Manager
{
    public class ManageModule<TService,TModel,TForm> : PageModule
        where TModel : IEntityModel
        where TService : EntityService<TService, TModel>
        where TForm: UpdateModule<TService,TModel>
    {
        public List<TModel> Data;
        protected TService Service;
        protected TForm FormUpdate;
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.httpContext.GetService<TService>();
            FormUpdate = this.httpContext.GetService<TForm>();            
        }
        public virtual List<TModel> GetSearchData() {
            return Service.GetAll().ToList();
        }
        public virtual IView Get() {
            Data = GetSearchData();
            return View();
        }
        public virtual IView GetUpdate(object Id) {
            return FormUpdate.Get(Id);
        }
        public virtual IView PostUpdate(object Id)
        {
            return FormUpdate.Post(Id);
        }
    }
}
