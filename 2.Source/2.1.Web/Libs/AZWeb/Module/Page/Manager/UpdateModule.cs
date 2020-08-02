using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace AZWeb.Module.Page.Manager
{
    [Auth]
    public abstract class UpdateModule<TService, TModel> : PageModule
        where TModel : IEntity, new()
        where TService : EntityService<TService, TModel>
    {
        public bool IsNew => this.Data == null;
        protected TService Service;
        public TModel Data;
        public List<ItemValue> Errors = new List<ItemValue>();
        public List<TableColumnAttribute> Columns { get; set; }
        [BindService]
        public IGenCodeService getGenCodeService;
        public virtual void Validate(TModel model, bool isNew) {
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
            return View(this.Data);
        }
        public virtual void DataFormToData(TModel DataForm, Func<PropertyInfo, bool> funProper = null)
        {
            if (this.Data == null) {
                foreach (var item in typeof(TModel).GetProperties()) {
                    var attr = item.GetAttribute<FieldAutoGenCodeAttribute>();
                    if (attr != null && item.GetValue(DataForm).IsNullOrEmpty()) {
                        item.SetValue(DataForm, getGenCodeService.GetGenCode(attr.Key, this.TenantId));
                    }
                }
                return;
            }
            if (!this.HttpContext.Request.HasFormContentType) return;
            var ModelType = typeof(TModel);
            foreach (var item in ModelType.GetProperties()) {
                if ((this.HttpContext.Request.Form.ContainsKey(item.Name) || (this.HttpContext.Request.Form.Files.GetListFiles(item.Name).Count > 0 && item.GetAttribute<FieldUploadFileAttribute>() != null)) && (funProper == null || funProper(item)))
                {
                    item.SetValue(this.Data, item.GetValue(DataForm));
                }
            }
        }
        public virtual void BeforeInsert(TModel DataForm) { }
        public virtual void AfterInsert(TModel DataForm) { }
        public virtual void BeforeUpdate(TModel DataForm, TModel DataBeforeSave) { }
        public virtual IView Post(long? Id)
        {
            var trans = this.HttpContext.GetService<EntityTransaction>();
            string messageOK = "";
            var DataForm = new TModel();
            this.HttpContext.BindFormTo(DataForm);
            trans.DoTransantion<TService>((t, t1) =>
            {
                if (Id != null && 0 != Id)
                {
                    this.Data = t1.GetById(Id);
                    DataFormToData(DataForm);
                    (this.Data as IEntityModel).UpdateAt = DateTime.Now;
                    (this.Data as IEntityModel).UpdateBy = User.Id;
                    Validate(this.Data, false);
                    BeforeUpdate(this.Data, DataForm);
                    t1.Update(this.Data);
                    messageOK = "Cập nhật dữ liệu thành công";
                }
                else
                {
                    DataFormToData(DataForm);
                    (DataForm as IEntityModel).CreateAt = DateTime.Now;
                    (DataForm as IEntityModel).CreateBy = User.Id;
                    if (this.TenantId != null && DataForm is ITenantEntity)
                    {
                        (DataForm as ITenantEntity).TenantId = this.TenantId;
                    }
                    Validate(DataForm, true);
                    BeforeInsert(DataForm);
                    var id = t1.Insert(DataForm);
                    typeof(TModel).GetProperty("Id").SetValue(DataForm, id);
                    AfterInsert(DataForm);
                    messageOK = "Thêm mới dữ liệu thành công";
                }
            });
            return trans.ErrorMessge.IsNullOrEmpty() ? Json(messageOK) : Json(trans.ErrorMessge, HttpStatusCode.BadRequest);
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
