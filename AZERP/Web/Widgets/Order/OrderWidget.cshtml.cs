using AZCore.Database.Attributes;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.Order
{
    [WidgetInfo(Name ="Đơn hàng")]
    public class OrderWidget : WidgetBase
    {
        public FilterDate FilterOrder { get; set; } = FilterDate.Day;
        public OrderWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
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
