using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.StockAdjustments
{
    public class FormUpdateStockAdj : UpdateModule<StockAdjusmentService, StockAdjusmentModel>
    {
        public FormUpdateStockAdj(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa đơn kiểm hàng";
        }
    }
}
