using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.TotalBill
{
    public class FormUpdateTotalBill : UpdateModule<TotalBillService, TotalBillModel>
    {
        public FormUpdateTotalBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hóa đơn tổng";
        }

    }
}
