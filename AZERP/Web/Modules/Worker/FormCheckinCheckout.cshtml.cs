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
using System.Threading.Tasks;

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
        public CheckinCheckoutEditor OnlyToday { get; set; } = CheckinCheckoutEditor.OnlyToday;
        [BindQuery]
        public int? Year { get; set; }
        public List<WorkerModel> Workers;

        public List<WorkerModel> DataWorkers;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public async Task<IView> PostShift(WorkShift ValueInput,long UserId,DateTime DateDay) {
            var data = await this.Service.ExecuteQueryAsync(p => {
                p.AddWhere("WorkerId", UserId);
                p.AddWhere("WorkDay", DateDay);
            });
            if (data.Count() > 0)
            {
                var curr = data.First();
                curr.WorkShift = ValueInput;
                curr.UpdateBy = this.User.Id;
                curr.UpdateAt = DateTime.Now;
                this.Service.Update(curr);
            }
            else {
                var curr = new WorkerCheckinCheckoutModel();
                curr.WorkDay = DateDay;
                curr.WorkerId = UserId;
                curr.TimeWork = 8;
                curr.WorkShift = ValueInput;
                curr.CreateAt = DateTime.Now;
                curr.CreateBy = this.User.Id;
                curr.CompanyId = this.CompanyId.Value;
                this.Service.Insert(curr);
            }
            return Json("Cập nhật thành công");
        }
        public async Task<IView> PostOver(float ValueInput, long UserId, DateTime DateDay)
        {
            var data = await this.Service.ExecuteQueryAsync(p => {
                p.AddWhere("WorkerId", UserId);
                p.AddWhere("WorkDay", DateDay);


            });
            if (data.Count() > 0)
            {
                var curr = data.First();
                curr.OverTimeWork = ValueInput;
                curr.UpdateBy = this.User.Id;
                curr.UpdateAt = DateTime.Now;
                this.Service.Update(curr);
            }
            else {
                var curr = new WorkerCheckinCheckoutModel();
                curr.WorkShift = WorkShift.DayShift;
                curr.WorkDay = DateDay;
                curr.WorkerId = UserId;
                curr.TimeWork = 8;
                curr.OverTimeWork = ValueInput;
                curr.CreateAt = DateTime.Now;
                curr.CreateBy = this.User.Id; 
                curr.CompanyId = this.CompanyId.Value;
                this.Service.Insert(curr);
            }
            return Json("Cập nhật thành công");
        }
        public object getDataBy(long UserId, DateTime DateDay,bool isOver=true) {

            if (this.Data != null && this.Data.Count > 0) {

                var objValue = this.Data.FirstOrDefault(p => p.WorkerId == UserId && p.WorkDay == DateDay);
                if (objValue != null) {

                    return isOver ? (object)objValue.OverTimeWork : (object)objValue.WorkShift;
                }
            }
            return null;
        }
        public override List<WorkerCheckinCheckoutModel> GetSearchData()
        {
            if (CompanyId != null) {
                Workers = workerService.ExecuteQuery((T) =>
                {
                    T.AddWhere("CompanyId", this.CompanyId);

                }).ToList();
                if (WorkerId != null&& WorkerId>0)
                {
                    DataWorkers = Workers.Where(p => p.Id == this.WorkerId).ToList();
                }
                else {
                    DataWorkers = Workers;
                }
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
                dtData.Columns.Add(string.Format("col_day_{0}", day.Day),typeof(string));
                if (day.DayOfWeek == System.DayOfWeek.Saturday|| day.DayOfWeek== System.DayOfWeek.Sunday)
                {
                    columns.Add(new TableColumnAttribute() { FieldName = string.Format("col_day_{0}", day.Day), Title = day.ToString("dd") , BackColor = Color.Red,Width=50});
                }
                else
                    columns.Add(new TableColumnAttribute() { FieldName = string.Format("col_day_{0}", day.Day), Title = day.ToString("dd"), Width = 50 });
            }
            if (this.DataWorkers != null) {
                foreach (var item in this.DataWorkers)
                {
                    var dr = dtData.NewRow();
                    dr["Fullname"] = item.FullName;
                    for (DateTime day = StartDate; day <= EndDate; day = day.AddDays(1))
                    {
                        var shift =this.getDataBy(item.Id, day, false);
                        if (shift != null) {
                            string shiftStr = "";
                            switch ((WorkShift)shift)
                            {

                                case WorkShift.DayShift:
                                    shiftStr = "N";
                                    break;
                                case WorkShift.NightShift:
                                    shiftStr = "D";
                                    break;
                                case WorkShift.NghiKhongLuong:
                                    shiftStr = "O";
                                    break;
                                case WorkShift.NghiPhep:
                                    shiftStr = "P";
                                    break;
                                default:
                                    break;
                            }
                            dr[string.Format("col_day_{0}", day.Day)] = shiftStr;
                        }
                        
                    }
                    dtData.Rows.Add(dr);
                    var dr2= dtData.NewRow();
                    dr2["Fullname"] = item.PhoneNumber;
                    for (DateTime day = StartDate; day <= EndDate; day = day.AddDays(1))
                    {
                        dr2[string.Format("col_day_{0}", day.Day)] = this.getDataBy(item.Id, day);
                    }
                    dtData.Rows.Add(dr2);
                }
            }
            excelGrid.SetTitle(string.Format("Bảng công từ ngày {0:dd/MM/yyyy} đến {1:dd/MM/yyyy} ",this.StartDate,this.EndDate));
            base.FillExcel(excelGrid, dtData, columns);
        }

    }
}
