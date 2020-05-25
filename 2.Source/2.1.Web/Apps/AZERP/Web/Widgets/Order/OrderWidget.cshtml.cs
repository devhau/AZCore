using System.Collections.Generic;
using AZERP.Data.Enums;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.Order
{
    public class OrderWidgetSetting : WidgetSetting { 
        public bool IsDay{get;set;}
        public FilterDate FilterOrder { get; set; } = FilterDate.Day;
    }
    [WidgetInfo(Name ="Đơn hàng")]
    public class OrderWidget : WidgetBase<OrderWidgetSetting>
    {
        public List<ItemValue> listFilterDate=null;
        public OrderWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            listFilterDate = typeof(FilterDate).GetListDataByDataType(null);
            
            switch(this.Setting.FilterOrder) {
                case FilterDate.Day:
                    this.Setting.Title = "Đơn hàng trong ngày";
                    break;
                case FilterDate.Month:
                    this.Setting.Title = "Đơn hàng trong tháng";
                    break;
                case FilterDate.Year:
                    this.Setting.Title = "Đơn hàng trong năm";
                    break;
            }
            this.Setting.Type = WidgetType.InfoBox;
            this.Value = System.DateTime.Now.ToLongTimeString();
            this.Setting.Icon = "fas fa-shopping-cart";
            this.Setting.IconColorClass = "bg-success";
            base.IntData();
        }
    }
}
