using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZWeb.Common.Manager
{
    public class ManageModule<TService,TModel,TForm> : PageModule
        where TModel : IEntityModel, new()
        where TService : EntityService<TService, TModel>
        where TForm: UpdateModule<TService,TModel>
    {
        public List<TModel> Data;
        protected TService Service;
        protected TForm FormUpdate;
        public List<TableColumnAttribute> Columns { get; set; }
        public virtual void BindTableColumn() {

            this.Columns = this.GetAttributes<TableColumnAttribute>().ToList();
        }
        public override void BeforeRequest()
        {
            BindTableColumn();
            FormUpdate.BeforeRequest();
            base.BeforeRequest();
        }
        public override void AfterRequest()
        {
            FormUpdate.AfterRequest();
            base.AfterRequest();
        }
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
