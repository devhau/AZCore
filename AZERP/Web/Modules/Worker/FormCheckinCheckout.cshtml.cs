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

namespace AZERP.Web.Modules.Worker
{
    public class FormCheckinCheckout : ManageModule<WorkerCheckinCheckoutService, WorkerCheckinCheckoutModel>
    {
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

        public override List<WorkerCheckinCheckoutModel> GetSearchData()
        {
            if (CompanyId == null) return null;
            Workers = workerService.ExecuteQuery((T) =>
            {
                T.AddWhere("CompanyId", this.CompanyId);
                if (WorkerId != null)
                {
                    T.AddWhere("Id", this.WorkerId);
                }

            }).ToList();
            return base.GetSearchData();
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
       
    }
}
