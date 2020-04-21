using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.UnitPrice
{
    public class FormUpdateUnitPrice : UpdateModule<UnitPriceService, UnitPriceModel>
    {
        public FormUpdateUnitPrice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Đơn giá";
        }

    }
}
