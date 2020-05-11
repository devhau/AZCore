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
            this.Setting.Title = "Đơn hàng trong ngày";            
            this.Setting.Type = WidgetType.InfoBox;
            this.Setting.Value = 10000;
            this.Setting.Icon = "fas fa-users";

            base.IntData();
        }
    }
}
