using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.Product
{
    [WidgetInfo(Name = "Sản phẩm")]
    public class ProductWidget : WidgetBase
    {
        public ProductWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            this.Title = "Đơn hàng trong ngày";            
            this.Type = WidgetType.InfoBox;
            this.Value = 10000;
            this.Icon = "fas fa-shopping-cart";
            base.IntData();
        }
    }
}
