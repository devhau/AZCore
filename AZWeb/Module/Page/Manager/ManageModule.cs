using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Excel;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AZWeb.Module.Page.Manager
{
    [Auth]
    public class ManageModule<TService, TModel> :  PageModule, IEntity, IPagination
         where TModel : IEntity, new()
        where TService : EntityService<TService, TModel>
    {
        protected ModuleInfoAttribute ModuleInfo;
        public List<TModel> Data;
        protected TService Service;
        public ExcelGrid excelGrid { get; protected set; }
        public List<TableColumnAttribute> Columns { get; set; }
        [BindQuery]
        public int PageIndex { get; set; }
        public int PageMax { get; set; }
        [BindQuery]
        public int PageSize { get; set; } = 20;
        public long PageTotal { get; set; }
        public long PageTotalAll { get; set; }
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.HttpContext.GetService<TService>();
            ModuleInfo = this.GetType().GetAttribute<ModuleInfoAttribute>();
        }
        public virtual void BindTableColumn()
        {
            this.Columns = this.GetType().GetAttributes<TableColumnAttribute>().ToList();
        }
        public virtual List<TModel> GetSearchData()
        {
            var proper = this.GetType().GetPropertyByQuerySearch();
            Action<QuerySQL> actionWhere = (T) =>
            {
                foreach (var p in proper)
                {
                    if (p.Property.GetValue(this) != null)
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
            this.PageMax = (int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize);
            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
            return Service.ExecuteQuery((T) => {             
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
            }).ToList();
        }
        public virtual IView Get()
        {
            if (ModuleInfo == null || this.HasPermission(ModuleInfo.ViewCode)) {
                Data = GetSearchData();
                return View();

            }
            return Json($"Bạn không có quyền truy cập : {Title}", HttpStatusCode.Unauthorized);
           
        }
        public override void BeforeRequest()
        {
            if (ModuleInfo != null)
            {
                this.Title = ModuleInfo.Title;
            }
            base.BeforeRequest();
            this.BindTableColumn();
        }
        protected virtual void BeforeDownload()
        {
        }
        protected virtual void AfterDownload()
        {
        }
        protected virtual void FillExcel(ExcelGrid excelGrid,object  Data, List<IExcelColumn> columns)
        {
            excelGrid.SetDataForGrid(Data, columns);
        }
        protected virtual ExcelGrid CreateExcelGrid() { 
            return new AZExcelGridWeb(this.HttpContext);
        }
        public virtual IView GetDownload()
        {
            if (ModuleInfo == null|| (this.HasPermission(ModuleInfo.ViewCode) && this.HasPermission(ModuleInfo.ExportCode)))
            {
                excelGrid = CreateExcelGrid();
                BeforeDownload();
                Data = GetSearchData();
                excelGrid.SetSheet(this.Title);
                FillExcel(excelGrid, Data, this.Columns.Cast<IExcelColumn>().ToList());
                AfterDownload();
                return DownloadFile(excelGrid.Download(), this.Title.ToUrlSlug() + ".xlsx", DownloadFileView.ExcelX);

            }
            return Json("Bạn không có quyền xuất file excel", HttpStatusCode.Unauthorized);
        }
    }
    public class ManageModule<TService, TModel, TForm> : ManageModule<TService,TModel>
        where TModel : IEntity, new()
        where TService : EntityService<TService, TModel>
        where TForm : UpdateModule<TService, TModel>
    {
        protected TForm FormUpdate;
        public override void AfterRequest()
        {
            base.AfterRequest();
            FormUpdate.AfterRequest();
        }
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            FormUpdate = this.HttpContext.GetService<TForm>();
            if (FormUpdate.GetType().GetProperty("ManagerForm") != null) {
                FormUpdate.GetType().GetProperty("ManagerForm").SetValue(FormUpdate, this);
            }
        }
       
        public virtual IView GetUpdate(long? Id) {
            if (ModuleInfo == null || (this.HasPermission(ModuleInfo.ViewCode) && ((Id ==null && this.HasPermission(ModuleInfo.AddCode))||(Id>=0&&this.HasPermission(ModuleInfo.EditCode)))))
            {
                FormUpdate.BeforeRequest();
                return FormUpdate.Get(Id);
            }
            return Json(Id==null?"Bạn không có quyền thêm mới": "Bạn không có quyền chỉnh sửa", HttpStatusCode.Unauthorized);

        }
        public virtual IView PostUpdate(long? Id)
        {
            if (ModuleInfo == null || (this.HasPermission(ModuleInfo.ViewCode) && ((Id == null && this.HasPermission(ModuleInfo.AddCode)) || (Id >= 0 && this.HasPermission(ModuleInfo.EditCode)))))
            {
                FormUpdate.BeforeRequest();
                return FormUpdate.Post(Id);
            }
            return Json(Id == null ? "Bạn không có quyền thêm mới" : "Bạn không có quyền chỉnh sửa", HttpStatusCode.Unauthorized);
        }
        public virtual IView PostDelete(long? Id)
        {
            if (ModuleInfo == null || (this.HasPermission(ModuleInfo.ViewCode) && this.HasPermission(ModuleInfo.RemoveCode)))
            {
                var modelId = Service.GetById(Id);
                Service.Delete(modelId);
                return Json("Xóa thành công", 200);
            }
            return Json("Bạn không có quyền xóa dữ liệu", HttpStatusCode.Unauthorized);
        }
    }
}
