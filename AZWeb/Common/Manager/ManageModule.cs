using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Excel;
using AZCore.Extensions;
using AZWeb.Common.Attributes;
using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZWeb.Common.Manager
{
    [Auth]
    public class ManageModule<TService, TModel, TForm> : PageModule, IEntity, IPagination
        where TModel : IEntityModel, new()
        where TService : EntityService<TService, TModel>
        where TForm : UpdateModule<TService, TModel>
    {
        public List<TModel> Data;
        protected TService Service;
        protected TForm FormUpdate;
        public List<TableColumnAttribute> Columns { get; set; }
        public AZExcelGrid excelGrid { get;private set;}
        [BindQuery]
        public int PageIndex { get; set; }
        public int PageMax { get; set; }
        [BindQuery]
        public int PageSize { get; set; } = 10;
        public long PageTotal { get; set; }
        public long PageTotalAll { get; set; }

        public virtual void BindTableColumn() {
            this.Columns = this.GetType().GetAttributes<TableColumnAttribute>().ToList();
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
            var proper = this.GetType().GetPropertyByQuerySearch();
            Action<QuerySQL> actionWhere = (T) =>
            {
                foreach (var p in proper) {
                    if(p.Property.GetValue(this)!=null)
                        T.AddWhere(p.Property.Name, p.Property.GetValue(this), p.OperatorSQL);
                }
            };
            this.PageTotalAll = Service.ExecuteNoneQuery((T) => {

                T.SetColumn("count(0)");
            
            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                actionWhere(T);
            });
            this.PageMax= (int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize);
            return Service.ExecuteQuery((T)=> {
                if (PageIndex <= 0) {
                    PageIndex = 1;
                }
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
            }).ToList();
        }
        public virtual IView Get() {
            Data = GetSearchData();
            return View();
        }
        public virtual IView GetUpdate(long? Id) {
            return FormUpdate.Get(Id);
        }
        protected virtual void BeforeDownload() {
        }
        protected virtual void AfterDownload()
        {
        }
        public virtual IView GetDownload()
        {
            excelGrid = new AZExcelGridWeb(this.httpContext);
            BeforeDownload();
            Data = GetSearchData();
            excelGrid.SetSheet(this.Title);
            excelGrid.SetDataForGrid(Data, this.Columns.Cast<IExcelColumn>().ToList());
            AfterDownload();
            return File(excelGrid.Download(), this.Title.ToUrlSlug()+".xlsx",FileView.ExcelX);
        }
        public virtual IView PostUpdate(long? Id)
        {
            var DataForm = new TModel();
            this.httpContext.BindFormTo(DataForm);
            return FormUpdate.Post(Id, DataForm);
        }
        public virtual IView PostDelete(long? Id)
        {
            var modelId=  Service.GetById(Id);
            Service.Delete(modelId);
            return Json("Thành công",200);
        }
    }
}
