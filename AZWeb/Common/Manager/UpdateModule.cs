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
    public class UpdateModule<TService, TModel> : PageModule 
        where TModel: IEntityModel, new()
        where TService:EntityService<TService,TModel>
    {
        protected TService Service;
        public TModel Data;
        public List<TableColumnAttribute> Columns { get; set; }
        public virtual void BindTableColumn()
        {
            this.Columns = this.GetType().GetAttributes<TableColumnAttribute>().ToList();
        }
        public override void BeforeRequest()
        {
            BindTableColumn();
            base.BeforeRequest();
        }
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
        public virtual void DataFormToData(TModel DataForm) {
            var ModelType = typeof(TModel);
            foreach (var item in ModelType.GetProperties()) {
                if (this.httpContext.Request.Form.ContainsKey(item.Name)) 
                {
                    item.SetValue(this.Data, item.GetValue(DataForm));
                }
            }
        }
        public virtual IView Post(object Id, TModel DataForm)
        {
            if (Id != null)
            {
                this.Data = this.Service.GetById(Id);
                DataFormToData(DataForm);
                Service.Update(this.Data);
            }
            else {
                Service.Insert(DataForm);
            }
            return Json("Cập nhật dữ liệu thành công",200);
        }
    }
}
