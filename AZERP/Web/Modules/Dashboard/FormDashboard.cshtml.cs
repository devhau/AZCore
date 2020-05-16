using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Web.Widgets.Order;
using AZERP.Web.Widgets.User;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using AZWeb.Module.TagHelper.Module;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using System;
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
        [BindService]
        public WidgetService widgetService { get; set; }
        public Dictionary<string, IWidget> dic = new Dictionary<string, IWidget>();
        [BindService]
        public IStartup startup { get; set; }
        public List<ButtonInfo> GetButtonInfo() => this.CreateButtons().ToList();
        protected virtual IEnumerable<ButtonInfo> CreateButtons()
        {
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-danger btn-sm az-btn  az-btn-add-widget az-link-popup",
                ModalSize = "az-modal-xl",
                CMD = "f1",
                Icon = "fas fa-cog",
                Text = "Thêm mới(F1)",
                Link= "/?h=AddWidget"
            };
           
        }
        public IView DeleteViewSetting(long? Id)
        {
            widgetService.Delete(p => p.Id == Id);
            return Json("Xóa thành công");
        
        }
            public IView PostViewSetting(string WidgetName, long? Id)
        {
            if (Id == null || Id <= 0)
            {
                var widget = getWidget(WidgetName);
                var wid = widget.GetSettingObject();
                var wid2 = wid.CopyTo(wid.GetType()).As<WidgetSetting>();
                this.HttpContext.BindFormTo(wid2);
                widgetService.Insert(new WidgetModel()
                {
                    CreateAt = DateTime.Now,
                    CreateBy = User.Id,
                    Name = wid.Title,
                    Widget = WidgetName,
                    Setting = wid2.ToJson()
                });
            }
            else
            {
                var widget = widgetService.GetById(Id); 
                var widget2 = getWidget(widget.Widget);
                this.HttpContext.BindFormTo(widget2.GetSettingObject());
                widget.Setting = widget2.GetSetting();
                widget.UpdateAt = DateTime.Now;
                widget.UpdateBy = User.Id;
                widgetService.Update(widget);
            }
            return Json("Thành công");
        }
        public IView GetViewSetting(string WidgetName,long? Id) {
           
            if (Id == null || Id <= 0) {
                var widget = getWidget(WidgetName);

                return widget.GetViewSetting();
            }
            else {
                var widgetModel = widgetService.GetById(Id);
                var widget = getWidget(widgetModel.Widget);

                this.Title = widget.GetName();
                return widget.SetSetting(widgetModel.Setting).GetViewSetting();
            }
        }
        public IView GetAddWidget()
        {
            this.GetType().Assembly.GetTypes().Where(p => p.GetAttribute<WidgetInfoAttribute>() != null).All(p => {

                dic[p.Name.Remove(p.Name.IndexOf("Widget"))] = HttpContext.RequestServices.GetService(p).As<IWidget>();

                return true;
            });
            this.Title = "Thêm mới widget";
            return View("AddWidget");
        }
        public IWidget getWidget(string widgetName) {
            return HttpContext.RequestServices.GetService(startup.GetType(string.Format("Web.Widgets.{0}.{0}Widget", widgetName))).As<IWidget>();
        }
        public IEnumerable<IWidget> Widgets()
        {
            foreach (var item in widgetService.GetAll()) {
                yield return getWidget(item.Widget).SetSetting(item.Setting).DoSetting(p =>{ p.Title = item.Name; p.Id = item.Id; });
            }
        }
        public IView GetSetting() {
           
            return Json("Cập nhật thành công");
        }
        protected override void IntData()
        {
            this.Title = "Bảng điền khiển";
            base.IntData();
        }
        public IView Get(){
           return View();
        }
    }
}
