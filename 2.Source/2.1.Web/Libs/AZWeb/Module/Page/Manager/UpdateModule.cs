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
        where TModel: IEntity, new()
        where TService:EntityService<TService,TModel>
    {
        public bool IsNew => this.Data == null;
        protected TService Service;
        public TModel Data;
        public List<ItemValue> Errors = new List<ItemValue>();
        public List<TableColumnAttribute> Columns { get; set; }
        [BindService]
        public IGenCodeService getGenCodeService;
        public virtual IView Validate(TModel model, bool isNew) {
            return null;
        }
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
        protected virtual void BeforeGet()
        {

        }
        protected virtual void AfterGet()
        {

        }
        public virtual IView Get(long? Id) {
            BeforeGet();
            if (Id != null && 0 != Id)
            {
                this.Data = this.Service.GetById(Id);
            }
            AfterGet();
            return View();
        }
        public virtual void DataFormToData(TModel DataForm, Func<PropertyInfo, bool> funProper = null)
        {
            if (this.Data == null) {
                foreach(var item in typeof(TModel).GetProperties()){
                    var attr = item.GetAttribute<FieldAutoGenCodeAttribute>();
                    if (attr != null&& item.GetValue(DataForm).IsNullOrEmpty()) {
                        item.SetValue(DataForm, getGenCodeService.GetGenCode(attr.Key, this.TenantId));
                    }
                }
                return;
            }
            var ModelType = typeof(TModel);
            foreach (var item in ModelType.GetProperties()) {
                if ((this.HttpContext.Request.Form.ContainsKey(item.Name)||(this.HttpContext.Request.Form.Files.GetListFiles(item.Name).Count>0&&item.GetAttribute<FieldUploadFileAttribute>()!=null)) && (funProper==null||funProper(item))) 
                {
                    item.SetValue(this.Data, item.GetValue(DataForm));
                }
            }
        }
        public virtual IView Post(long? Id)
        {
            var DataForm = new TModel();
            this.HttpContext.BindFormTo(DataForm);
            if (Id != null&& 0!=Id)
            {
                this.Data = this.Service.GetById(Id);
                DataFormToData(DataForm);
                (this.Data as IEntityModel).UpdateAt = DateTime.Now;
                (this.Data as IEntityModel).UpdateBy = User.Id;
                var rs = Validate(this.Data,false);
                if (rs==null)
                {
                    Service.Update(this.Data);
                    return Json("Cập nhật dữ liệu thành công");
                }
                return rs;
            }
            else {
                DataFormToData(DataForm);
                (DataForm as IEntityModel).CreateAt = DateTime.Now;
                (DataForm as IEntityModel).CreateBy = User.Id;
                if (this.TenantId != null) {
                    (DataForm as IEntityModel).TenantId = this.TenantId;
                }
                var rs = Validate(DataForm,true);
                if (rs == null)
                {
                    Service.Insert(DataForm);
                    return Json("Thêm mới dữ liệu thành công");
                }
                return rs;
            }
        }
    }

    public class UpdateModule<TService, TModel, TManager> : UpdateModule<TService, TModel>
        where TModel : IEntity, new()
        where TService : EntityService<TService, TModel>
        where TManager: ManageModule<TService, TModel>
    {
        public UpdateModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public TManager ManagerForm { get; set; }
    }
}
