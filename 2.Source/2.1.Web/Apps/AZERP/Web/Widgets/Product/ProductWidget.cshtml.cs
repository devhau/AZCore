using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.Product
{
    public class ProductWidgetSetting: WidgetSetting
    { 
    }
    [WidgetInfo(Name = "Sản phẩm",Icon = "fab fa-product-hunt",Type = WidgetType.InfoBox)]
    public class ProductWidget : WidgetBase<ProductWidgetSetting>
    {
        public ProductWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        protected override void DoProcessData()
        {
            this.Value = 100;
        }

    }
}
