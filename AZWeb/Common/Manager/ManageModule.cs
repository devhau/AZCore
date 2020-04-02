using AZCore.Database;
using AZCore.Excel;
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
    [Auth]
    public class ManageModule<TService, TModel, TForm> : PageModule
        where TModel : IEntityModel, new()
        where TService : EntityService<TService, TModel>
        where TForm : UpdateModule<TService, TModel>
    {
        public List<TModel> Data;
        protected TService Service;
        protected TForm FormUpdate;
        public List<TableColumnAttribute> Columns { get; set; }
        public AZExcelGrid excelGrid { get;private set;}
        public virtual void BindTableColumn() {
            this.Columns = this.GetType().GetAttributes<TableColumnAttribute>().ToList();
        }
        public override void BeforeRequest()
        {
            BindTableColumn();
            FormUpdate.BeforeRequest();
            base.BeforeRequest();
            excelGrid = new AZExcelGridWeb(this.httpContext);
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
        public virtual IView GetUpdate(long? Id) {
            return FormUpdate.Get(Id);
        }
        public virtual IView GetDownload()
        {
            Data = GetSearchData();
            excelGrid.SetSheet(this.Title);
            excelGrid.SetDataForGrid(Data, this.Columns.Cast<IExcelColumn>().ToList());
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
