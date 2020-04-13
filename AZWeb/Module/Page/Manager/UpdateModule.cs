using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AZWeb.Module.Page.Manager
{
    [Auth]
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
        protected override void IntData()
        {

            this.IsTheme = false;
            base.IntData();
        }
        public UpdateModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.HttpContext.GetService<TService>();
        }
        public virtual IView Get(long? Id) {
            if (Id != null && 0 != Id)
            {
                this.Data = this.Service.GetById(Id);
            }
            return View();
        }
        public virtual void DataFormToData(TModel DataForm, Func<PropertyInfo, bool> funProper = null)
        {
            if (this.Data == null) return;
            var ModelType = typeof(TModel);
            foreach (var item in ModelType.GetProperties()) {
                if (this.HttpContext.Request.Form.ContainsKey(item.Name) && (funProper==null||funProper(item))) 
                {
                    item.SetValue(this.Data, item.GetValue(DataForm));
                }
            }
        }
        public virtual IView Post(long? Id, TModel DataForm)
        {
            if (Id != null&& 0!=Id)
            {
                this.Data = this.Service.GetById(Id);
                DataFormToData(DataForm);
                this.Data.UpdateAt = DateTime.Now;
                Service.Update(this.Data);
                return Json("Cập nhật dữ liệu thành công", 200);
            }
            else {
                DataFormToData(DataForm);
                DataForm.CreateAt = DateTime.Now;

                Service.Insert(DataForm);
                return Json("Thêm mới dữ liệu thành công", 200);
            }
        }
    }
}
