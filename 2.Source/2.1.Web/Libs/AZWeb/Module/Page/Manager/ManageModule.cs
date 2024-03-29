﻿using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZCore.Excel;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.TagHelper.Module;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AZWeb.Module.Page.Manager
{
    [Auth]
    public abstract class ManageModule<TService, TModel> : SearchModule<TService,TModel>
         where TModel : IEntity, new()
        where TService : EntityService<TModel>
    {
        public List<ButtonInfo> GetButtonInfo() => this.CreateButtons().ToList();
        protected virtual IEnumerable<ButtonInfo> CreateButtons() {

            yield return new ButtonInfo() {            
                 ClassName= "btn btn-success btn-sm az-btn az-btn-add",
                 CMD= "f1",
                 PermisisonCode=this.ModuleInfo?.AddCode,
                 Icon= "far fa-plus-square",
                 Text= "Thêm Mới (F1)"
            };
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-info btn-sm az-btn az-btn-export",
                CMD = "f2",
                PermisisonCode = this.ModuleInfo?.ExportCode,
                Icon = "fas fa-file-export",
                Text = "Xuất Excel (F2)"
            };
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-secondary btn-sm az-btn az-btn-import",
                CMD = "f3",
                PermisisonCode = this.ModuleInfo?.ImportCode,
                Icon = "fas fa-file-upload",
                Text = "Nhập Excel (F3)"
            };
        }
        protected ModuleInfoAttribute ModuleInfo;
        public ExcelGrid excelGrid { get; protected set; }
        public List<TableColumnAttribute> Columns { get; set; }
      
        public ManageModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            ModuleInfo = this.GetType().GetAttribute<ModuleInfoAttribute>();
        }
      
        public virtual void BindTableColumn()
        {
            this.Columns = this.GetType().GetAttributes<TableColumnAttribute>().ToList();
        }
      
        public override IView Get()
        {
            if (ModuleInfo == null || this.HasPermission(ModuleInfo.ViewCode)) {
                return base.Get();
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
        where TService : EntityService<TModel>
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
