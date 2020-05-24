using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.FixedBill
{
    public class FormUpdateFixedBill : UpdateModule<FixedBillService, FixedBillModel>
    {
        public FormUpdateFixedBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hóa đơn cố định";
        }

    }
}
