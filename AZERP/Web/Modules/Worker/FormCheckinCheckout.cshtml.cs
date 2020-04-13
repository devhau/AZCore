using AZCore.Database;
using AZCore.Excel;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AZERP.Web.Modules.Worker
{
    public class FormCheckinCheckout : ManageModule<WorkerCheckinCheckoutService, WorkerCheckinCheckoutModel>
    {
      
        WorkerService workerService;
        public FormCheckinCheckout(IHttpContextAccessor httpContext) : base(httpContext)
        {
            workerService = this.HttpContext.GetService<WorkerService>();
        }
        [QuerySearch]
        public long? CompanyId { get; set; }
        [QuerySearch]
        public long? WorkerId { get; set; }
        [BindQuery]
        public Month? Month { get; set; }
        [BindQuery]
        public bool OnlyToday { get; set; } = true;
        [BindQuery]
        public int? Year { get; set; }
        public List<WorkerModel> Workers;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public IView PostShift(WorkShift shift) {
            return Json("Cập nhật thành công");
        }
        public override List<WorkerCheckinCheckoutModel> GetSearchData()
        {
            if (CompanyId != null) {
                Workers = workerService.ExecuteQuery((T) =>
                {
                    T.AddWhere("CompanyId", this.CompanyId);
                    if (WorkerId != null)
                    {
                        T.AddWhere("Id", this.WorkerId);
                    }

                }).ToList();
            }
            
            var data= base.GetSearchData();

            return data;
        }
        protected override void IntData()
        {
            this.Title = "Bảng chấm công";
            if (this.Year == null) this.Year = DateTime.Now.Year;
            if (this.Month == null) this.Month = (Month)DateTime.Now.Month;
            this.StartDate = new DateTime(this.Year.Value,(int)this.Month.Value,1);
            this.EndDate = this.StartDate.AddMonths(1).AddDays(-1);
            base.IntData();
        }      
        protected override void FillExcel(ExcelGrid excelGrid, object Data, List<IExcelColumn> columns)
        {
            columns = new List<IExcelColumn>();
            var dtData = new DataTable();
            dtData.Columns.Add("Fullname", typeof(string));
            columns.Add(new TableColumnAttribute() { FieldName="Fullname",Title="Họ Tên"});
            for (DateTime day = StartDate ; day <= EndDate;day=day.AddDays(1))
            {
                dtData.Columns.Add(string.Format("col_day_{0}", day.Day),typeof(DateTime));
                if (day.DayOfWeek == System.DayOfWeek.Saturday|| day.DayOfWeek== System.DayOfWeek.Sunday)
                {
                    columns.Add(new TableColumnAttribute() { FieldName = string.Format("col_day_{0}", day.Day), Title = day.ToString("dd/MM/yyyy") , BackColor = Color.Red});
                }
                else
                    columns.Add(new TableColumnAttribute() { FieldName = string.Format("col_day_{0}", day.Day), Title = day.ToString("dd/MM/yyyy") });
            }
            if (this.Workers != null) {
                foreach (var item in this.Workers)
                {
                    var dr = dtData.NewRow();
                    dr["Fullname"] = item.FullName;
                    dtData.Rows.Add(dr);
                    var dr2= dtData.NewRow();
                    dr2["Fullname"] = item.PhoneNumber;
                    dtData.Rows.Add(dr2);
                }
            }
            excelGrid.SetTitle(string.Format("Bảng công từ ngày {0:dd/MM/yyyy} đến {1:dd/MM/yyyy} ",this.StartDate,this.EndDate));
            base.FillExcel(excelGrid, dtData, columns);
        }

    }
}
