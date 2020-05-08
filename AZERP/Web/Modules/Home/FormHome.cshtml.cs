using AZERP.Web.Widgets.User;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AZERP.Web.Modules.Home
{
    [Auth]
    public class FormHome:PageModule
    {
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        public IEnumerable<IWidget> GetWidgets()
        {
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => t.Title = "Test dữ liệu 1");
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => t.Title = "Test dữ liệu 2");
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => t.Title = "Test dữ liệu 3");
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => t.Title = "Test dữ liệu 4");
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 6";t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 7"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 8"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 9"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 10"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 11"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 12"; t.Type = WidgetType.PanelBox; });
            yield return this.HttpContext.GetService<UserWidget>().DoSetting((t) => { t.Title = "Test dữ liệu 13"; t.Type = WidgetType.PanelBox; });
        
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
