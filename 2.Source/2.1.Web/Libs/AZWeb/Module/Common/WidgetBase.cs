using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public enum WidgetWidth {
        [Field(Display ="Column 1",Value = "col-12 col-sm-2 col-md-1")]
        Col1,
        [Field(Display = "Column 2", Value = "col-12 col-sm-4 col-md-2")]
        Col2,
        [Field(Display = "Column 3", Value = "col-12 col-sm-6 col-md-3")]
        Col3,
        [Field(Display = "Column 4", Value = "col-12 col-sm-6 col-md-4")]
        Col4,
        [Field(Display = "Column 5", Value = "col-12 col-sm-6 col-md-5")]
        Col5,
        [Field(Display = "Column 6", Value = "col-12 col-sm-6 col-md-6")]
        Col6,
        [Field(Display = "Column 7", Value = "col-12 col-sm-6 col-md-7")]
        Col7,
        [Field(Display = "Column 8", Value = "col-12 col-sm-12 col-md-8")]
        Col8,
        [Field(Display = "Column 9", Value = "col-12 col-sm-12 col-md-9")]
        Col19,
        [Field(Display = "Column 10", Value = "col-12 col-sm-12 col-md-10")]
        Col10,
        [Field(Display = "Column 11", Value = "col-12 col-sm-12 col-md-11")]
        Col11,
        [Field(Display = "Column 12", Value = "col-12 col-sm-12 col-md-12")]
        Col12
    }
    public interface IWidget {
        long Id { get; set; }
        string Title { get; set; }
        object Value { get; set; }
        IView GetViewSetting();
        IHtmlContent GetContent();
        string GetName();
        string GetIcon();
        string GetTitle();
        string GetSetting();
        bool CheckPermission();
        WidgetSetting GetSettingObject();
        IWidget SetSetting(string setting);
        IWidget DoSetting(Action<IWidget> acction=null);
    }
    public enum WidgetType {
        [Field(Display = "Thông tin")]
        InfoBox,
        [Field(Display = "Biểu đồ hoặc báo cáo")]
        PanelBox,
        [Field(Display = "Hiển thị fullbox")]
        FulBox
    }
    public class WidgetSetting:IEntity {
        public string Icon { get; set; } = "fas fa-cog";
        public string Title { get; set; }
        public object Value { get; set; }
        public string BackgroundColorClass { get; set; } = "";
        public string IconColorClass { get; set; } = "bg-info";
        public WidgetWidth WidthClass { get; set; } = WidgetWidth.Col3;
        public WidgetType Type { get; set; } = WidgetType.PanelBox;
    }
    public abstract class WidgetBase : WidgetBase<WidgetSetting>
    {
        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
    
    public abstract class WidgetBase<TSetting> : PageBase, IWidget
        where TSetting:WidgetSetting,new()
    {
        protected WidgetInfoAttribute info { get; set; }
        public virtual bool CheckPermission() {
            return this.HasPermission(info?.Permission);
        }
        protected abstract void DoProcessData();
        public IWidget DoSetting(Action<IWidget> acction = null) {
            if (acction != null) acction(this);
            return this;
        }
        public IWidget SetSetting(string setting)
        { 
            if(!setting.IsNullOrEmpty())
                this.Setting = setting.ToObject<TSetting>();
            return this;
        }
        
        public TSetting Setting { get; set; } = new TSetting();
        RenderView renderView { get; }
        public string Title { get; set; } 
        public object Value { get; set; }
        public long Id { get; set; }

        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.renderView = new RenderView(this.HttpContext);
            this.IntData();
            info = this.GetType().GetAttribute<WidgetInfoAttribute>();
            this.Title = this.info?.Name;
            this.Setting.Icon = this.info?.Icon;
            this.Setting.BackgroundColorClass = this.info?.BackgroundColorClass;
            this.Setting.WidthClass = info?.WidthClass ?? WidgetWidth.Col1;
            this.Setting.IconColorClass = this.info?.IconColorClass;
        }
        public async Task<IHtmlContent> GetContentAsync() {
            return await renderView.GetContentHtmlFromView(View() as HtmlView);
        }
        protected string GetWidth(WidgetWidth _widthClass) {
            return string.Format("{0}  ", _widthClass.GetItemValueByEnum()?.FieldValue);
        }
        protected virtual void AddSettingButton(StringBuilder widget)
        {
            widget.Append(@"<div class='btn-group az-widget-button-setting'>
                    <button type='button' class='btn btn-tool dropdown-toggle' data-toggle='dropdown' aria-expanded='false'>
                      <i class='fas fa-cog'></i>
                    </button>
                    <div class='dropdown-menu dropdown-menu-right' role='menu' x-placement='bottom-end' style='position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(46px, 19px, 0px);'>
                      <a class='dropdown-item'>Làm mới</a>
                      <a class='dropdown-item az-widget-setting'>Thiết lập</a>
                    </div>
                  </div>");
        }
        protected virtual string LayoutWidget() {
            StringBuilder widget = new StringBuilder();
            widget.AppendFormat("<div class=\"{0} az-widget \" widget-id=\"{1}\">", GetWidth(this.Setting.WidthClass),this.Id);
            if (this.Setting.Type == WidgetType.InfoBox)
            {
                widget.AppendFormat("<div class=\"az-info-box info-box {0}\">", this.Setting.BackgroundColorClass);               
                widget.AppendFormat("<span class=\"info-box-icon {1}\"><i class=\"{0}\"></i></span>", this.Setting.Icon, this.Setting.IconColorClass);
                widget.Append("<div class=\"info-box-content\">");
                widget.AppendFormat("<span class=\"info-box-text\">{0}</span>", this.Setting.Title.IsNullOrEmpty() ? this.Title: this.Setting.Title);
                widget.AppendFormat("<span class=\"info-box-number\">{0}</span>", this.Value);
                widget.Append("</div>");
                AddSettingButton(widget);
                widget.Append("</div>");
            }
            else if(this.Setting.Type == WidgetType.PanelBox)
            {
                widget.AppendFormat("<div class=\"az-card-box card {0}\">", this.Setting.BackgroundColorClass);
                widget.Append("<div class=\"card-header\">");
                widget.AppendFormat("<h3 class=\"card-title\"><i class=\"{0}\"></i> {1}</h3>", this.Setting.Icon, this.Setting.Title.IsNullOrEmpty()?this.Title: this.Setting.Title);
                widget.Append("<div class=\"card-tools\">");
                widget.Append("<button type=\"button\" class=\"btn btn-tool\" data-card-widget=\"collapse\"> <i class=\"fas fa-minus\"></i></button>");
                AddSettingButton(widget);
                widget.Append("</div>");
                widget.Append("</div>");
                widget.Append("<div class=\"card-body p-0\">");
                widget.Append(GetContentAsync().ConfigureAwait(false).GetAwaiter().GetResult().GetString());
                widget.Append("</div>");
                widget.Append("</div>");
            }
            else
            {
                widget.AppendFormat("<div class=\"az-full-box {0}\">", this.Setting.BackgroundColorClass);
                AddSettingButton(widget);
                widget.Append(GetContentAsync().ConfigureAwait(false).GetAwaiter().GetResult().GetString());
                widget.Append("</div>");

            }
            widget.Append("</div>");
            return widget.ToString();
        }
        public IHtmlContent GetContent()
        {
            this.DoProcessData();
            return new HtmlString(LayoutWidget());
        }
        public virtual IView PostData() {
            return null;
        }
       
        public string GetTitle() {
            return "Thiết lập : " + this.Setting?.Title; 
        }
        public IView GetViewSetting() {
            return View("Setting");
        }
        #region --- View ---
        protected virtual IView View()
        {
            return View(this);
        }
        protected virtual IView View(object model)
        {
            return View("", model);
        }
        protected virtual IView View(string viewName)
        {
            return View(viewName, this);
        }
        protected virtual IView View(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = this.GetType().Name;
            return new HtmlView()
            {
                Model = model,
                ViewName = viewName,
                Path = string.Format("~/{0}", this.GetPathMoule()),
                Module = this,
            };
        }

        public string GetSetting()
        {
            return this.Setting.ToJson();
        }

        public string GetName()
        {
            return string.Format("<i class=\"{0}\"/> {1}",this.Setting?.Icon,this.Title);
        }

        public WidgetSetting GetSettingObject()
        {
            return this.Setting;
        }

        public string GetIcon()
        {
            return this.Setting?.Icon;
        }


        #endregion
    }
}
