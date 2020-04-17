using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.PurchaseOrders
{
    public class FormUpdatePurchaseOrders : UpdateModule<PurchaseOrderService, PurchaseOrderModel>
    {
        public FormUpdatePurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa đơn nhập hàng";
        }
    }
}
