using System.Collections.Generic;
using AZERP.Data.Enums;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.TagHelper.Module;

namespace AZERP.Web.Widgets.Order
{
    public class OrderWidgetSetting : WidgetSetting { 
        public FilterDate FilterOrder { get; set; } = FilterDate.Day;
    }
    [WidgetInfo(Name ="Đơn hàng")]
    public class OrderWidget : WidgetBase<OrderWidgetSetting>
    {
        public List<ItemValue> listFilterDate=null;
        public OrderWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public ChartOption ChartOption = new ChartOption();
        protected override void IntData()
        {
            listFilterDate = typeof(FilterDate).GetListDataByDataType(null);
            
            this.Value = System.DateTime.Now.ToLongTimeString();
            this.Setting.Icon = "fas fa-shopping-cart";
            this.Setting.IconColorClass = "bg-success";
            // thiết lập Chart
            ChartOption.type = "bar";
            ChartOption.data = new
            {
                labels = new [] { "Sản phẩm 1", "Sản phẩm 2", "Sản phẩm 3", "Green", "Purple", "Orange" },
                datasets = new [] {
                    new {
                        label = "Doanh số trong ngày",
                        data = new []{ 12, 19, 3, 5, 2, 3 },
                        backgroundColor = new []{ 
                            "rgba(255, 99, 132, 0.2)",
                            "rgba(54, 162, 235, 0.2)",
                            "rgba(255, 206, 86, 0.2)",
                            "rgba(75, 192, 192, 0.2)",
                            "rgba(153, 102, 255, 0.2)",
                            "rgba(255, 159, 64, 0.2)"
                        },
                        borderColor = new [] {
                            "rgba(255, 99, 132, 1)",
                            "rgba(54, 162, 235, 1)",
                            "rgba(255, 206, 86, 1)",
                            "rgba(75, 192, 192, 1)",
                            "rgba(153, 102, 255, 1)",
                            "rgba(255, 159, 64, 1)"
                        },
                        borderWidth = 1
                    }
                }

            };
            base.IntData();
        }
    }
}
