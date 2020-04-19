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
        protected ModulePermissionAttribute Permission;
        public List<TModel> Data;
        protected TService Service;
        public ExcelGrid excelGrid { get; protected set; }
        public List<TableColumnAttribute> Columns { get; set; }
        [BindQuery]
        public int PageIndex { get; set; }
        public int PageMax { get; set; }
        [BindQuery]
        public int PageSize { get; set; } = 10;
        public long PageTotal { get; set; }
        public long PageTotalAll { get; set; }
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.HttpContext.GetService<TService>();
            Permission = this.GetType().GetAttribute<ModulePermissionAttribute>();
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
            return Service.ExecuteQuery((T) => {
                if (PageIndex <= 0)
                {
                    PageIndex = 1;
                }
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
            }).ToList();
        }
        public virtual IView Get()
        {
            if (Permission == null || this.HasPermission(Permission.ViewCode)) {
                Data = GetSearchData();
                return View();

            }
            return Json($"Bạn không có quyền truy cập : {Title}", HttpStatusCode.Unauthorized);
           
        }
        public override void BeforeRequest()
        {            
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
            if (Permission==null|| (this.HasPermission(Permission.ViewCode) && this.HasPermission(Permission.ExportCode)))
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
        public override void BeforeRequest()
        {
            base.BeforeRequest();
        }
        public override void AfterRequest()
        {
            base.AfterRequest();
            FormUpdate.AfterRequest();
        }
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            FormUpdate = this.HttpContext.GetService<TForm>();
        }
       
        public virtual IView GetUpdate(long? Id) {
            if (Permission == null || (this.HasPermission(Permission.ViewCode) && ((Id ==null && this.HasPermission(Permission.AddCode))||(Id>=0&&this.HasPermission(Permission.EditCode)))))
            {
                FormUpdate.BeforeRequest();
                return FormUpdate.Get(Id);
            }
            return Json(Id==null?"Bạn không có quyền thêm mới": "Bạn không có quyền chỉnh sửa", HttpStatusCode.Unauthorized);

        }
        public virtual IView PostUpdate(long? Id)
        {
            if (Permission == null || (this.HasPermission(Permission.ViewCode) && ((Id == null && this.HasPermission(Permission.AddCode)) || (Id >= 0 && this.HasPermission(Permission.EditCode)))))
            {
                FormUpdate.BeforeRequest();
                var DataForm = new TModel();
                this.HttpContext.BindFormTo(DataForm);
                return FormUpdate.Post(Id, DataForm);
            }
            return Json(Id == null ? "Bạn không có quyền thêm mới" : "Bạn không có quyền chỉnh sửa", HttpStatusCode.Unauthorized);
        }
        public virtual IView PostDelete(long? Id)
        {
            if (Permission == null || (this.HasPermission(Permission.ViewCode) && this.HasPermission(Permission.RemoveCode)))
            {
                var modelId = Service.GetById(Id);
                Service.Delete(modelId);
                return Json("Xóa thành công", 200);
            }
            return Json("Bạn không có quyền xóa dữ liệu", HttpStatusCode.Unauthorized);
        }
    }
}
