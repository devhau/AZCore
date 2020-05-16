using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.ChangeBill
{
    public class FormUpdateChangeBill : UpdateModule<ChangeBillService, ChangeBillModel>
    {
        public FormUpdateChangeBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hóa đơn lưu động";
        }

    }
}
