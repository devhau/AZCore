using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.Order
{
    public class OrderWidgetSetting : WidgetSetting { 
    
    }
    [WidgetInfo(Name ="Đơn hàng")]
    public class OrderWidget : WidgetBase<OrderWidgetSetting>
    {
        public FilterDate FilterOrder { get; set; } = FilterDate.Day;
        public OrderWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            this.Setting.Title = "Đơn hàng trong ngày";            
            this.Setting.Type = WidgetType.InfoBox;
            this.Setting.Value = 10000;
            this.Setting.Icon = "fas fa-shopping-cart";
            this.Setting.IconColorClass = "bg-success";
            base.IntData();
        }
    }
}
