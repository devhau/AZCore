using AZCore.Database;
using AZERP.Data.Components.Tables;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Common.Attributes;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AZERP.Web.Modules.Worker
{
    public class FormCheckinCheckout : ManageModule<WorkerCheckinCheckoutService, WorkerCheckinCheckoutModel>
    {
        public class AZWorkeCheckinCheckout : AZDataCheckinCheckout
        {
            public override StringBuilder GetContentCell(IEntity User, DateTime day)
            {
                var build= new StringBuilder();
                if (((WorkerModel)User).StartWork <= day && day<=DateTime.Now.Date) {
                    var DataCheckIn = this.DataCheckInCheckOut.Cast<WorkerCheckinCheckoutModel>().FirstOrDefault(p => p.WorkerId == ((WorkerModel)User).Id && p.WorkDay == day);
                    build.AppendFormat("<select class='form-control' tabindex='{0}'>", day.Date.Day);

                    build.AppendFormat("<option value=\"{0}\" name=\"{1}\" >{2}</option>", "", "", "");
                    build.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3}>{2}</option>", "DayShift", "DayShift", "Ca ngày",DataCheckIn!=null&&DataCheckIn.WorkShift==EnumWorkShift.DayShift? "selected":"");
                    build.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3}>{2}</option>", "NightShift", "NightShift", "Ca đêm", DataCheckIn != null && DataCheckIn.WorkShift == EnumWorkShift.NightShift ? "selected" : "");
                    build.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3}>{2}</option>", "NghiPhep", "NghiPhep", "Nghỉ phép", DataCheckIn != null && DataCheckIn.WorkShift == EnumWorkShift.NghiPhep ? "selected" : "");
                    build.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3}>{2}</option>", "NghiKhongLuong", "NghiKhongLuong", "Nghỉ không lương", DataCheckIn != null && DataCheckIn.WorkShift == EnumWorkShift.NghiKhongLuong ? "selected" : "");
                    build.Append("</select>");
                    build.AppendFormat("<input class='form-control' value='{0}' placeholder='Tăng ca(h)' tabindex='{1}'/>", DataCheckIn!=null&&DataCheckIn.OverTimeWork>0? DataCheckIn.OverTimeWork.ToString():"", day.Date.Day);
                }
                return build;
            }
            public override StringBuilder GetContentUser(IEntity User)
            {
                var build = new StringBuilder();
                build.AppendFormat("<b>{0}</b>",((WorkerModel)User).FullName);
                build.AppendFormat("<p>{0}</p>", ((WorkerModel)User).PhoneNumber);
                return build;
            }
        }
        WorkerService workerService;
        public FormCheckinCheckout(IHttpContextAccessor httpContext) : base(httpContext)
        {
            workerService = this.httpContext.GetService<WorkerService>();
        }
        [QuerySearch]
        public long? CompanyId { get; set; }
        [QuerySearch]
        public long? WorkerId { get; set; }
        [BindQuery]
        public EnumMonth? Month { get; set; }
        [BindQuery]
        public int? Year { get; set; }
        public List<WorkerModel> Workers;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public AZWorkeCheckinCheckout AZData { get; set; }
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

            AZData = new AZWorkeCheckinCheckout()
            {
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Users = this.Workers!=null? this.Workers.Cast<IEntity>().ToList():null,
                DataCheckInCheckOut = data.Cast<IEntity>().ToList()
            };
            return data;
        }
        protected override void IntData()
        {
            this.Title = "Bảng chấm công";
            if (this.Year == null) this.Year = DateTime.Now.Year;
            if (this.Month == null) this.Month = (EnumMonth)DateTime.Now.Month;
            this.StartDate = new DateTime(this.Year.Value,(int)this.Month.Value,1);
            this.EndDate = this.StartDate.AddMonths(1).AddDays(-1);
            base.IntData();
        }
        public string GetCellWorker(WorkerModel worker,DateTime date) {
            StringBuilder buildCell = new StringBuilder();
            buildCell.Append("<select class='form-control'>");
            buildCell.Append("<option value='1' > Nghỉ làm</option>");
            buildCell.Append("<option value='2' > Ca Ngày</option>");
            buildCell.Append("<option value='3' > Ca Đêm</option>");
            buildCell.Append("</select>");
            return buildCell.ToString();
        }
       
    }
}
