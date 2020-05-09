using AZERP.Web.Widgets.Order;
using AZERP.Web.Widgets.User;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using AZWeb.Module.TagHelper.Module;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Dashboard
{
    [Auth]
    public class FormDashboard:PageModule
    {
        public FormDashboard(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public List<ButtonInfo> GetButtonInfo() => this.CreateButtons().ToList();
        protected virtual IEnumerable<ButtonInfo> CreateButtons()
        {
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-success btn-sm az-btn",
                CMD = "f1",
                Icon = "fas fa-cog",
                Text = "Thiết lập bảng điều khiển (F1)"
            };
           
        }
        public IEnumerable<IWidget> Widgets()
        {
            yield return this.HttpContext.GetService<OrderWidget>().DoSetting((t) => {  t.WidthClass = WidgetWidth.Col3; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Số lượng tài khoản"; t.WidthClass = WidgetWidth.Col3; });
        
    }
        protected override void IntData()
        {
            this.Title = "Bảng điền khiển";
            base.IntData();
        }
        public string id { get; set; }
        public IView Get(){
           return View();
        }
    }
}
