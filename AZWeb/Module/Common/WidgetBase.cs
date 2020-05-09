using AZCore.Database.Attributes;
using AZWeb.Extensions;
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
        string Icon { get; set; }
        string Title { get; set; }
        object Value { get; set; }
        IHtmlContent GetContent();
    }
    public enum WidgetType { 
        None,
        InfoBox,
        PanelBox
    }
    public class WidgetSetting { 
    
    }
    public class WidgetBase : WidgetBase<WidgetSetting>
    {
        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
    }
    
    public class WidgetBase<TSetting> : ModuleBase, IWidget
        where TSetting:WidgetSetting,new()
    {
        public IWidget DoSetting(Action<WidgetBase<TSetting>> acction) {
            if (acction != null) acction(this);
            return this;
        }
        public string Icon { get; set; } = "fas fa-cog";
        public string Title { get; set; }
        public object Value { get; set; }
        public string BackgroundColorClass { get; set; } = "";
        public string IconColorClass { get; set; } = "bg-info";
        public WidgetWidth WidthClass { get; set; } = WidgetWidth.Col2;
        public WidgetType Type { get; set; } = WidgetType.PanelBox;

        public TSetting Setting { get; set; } = new TSetting();
        RenderView renderView { get; }
        public WidgetBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.renderView = new RenderView(this.HttpContext);
            this.IntData();
        }
        public async Task<IHtmlContent> GetContentAsync() {
            var rs= await renderView.GetContentHtmlFromView(View() as HtmlView);
            return rs;
        }
        public string GetWidth(WidgetWidth _widthClass) {
            return string.Format("{0}  ", _widthClass.GetItemValueByEnum()?.FieldValue);
        }
        public virtual string LayoutWidget(string layoutContent) {
            StringBuilder widget = new StringBuilder();
            widget.AppendFormat("<div class=\"{0}\">", GetWidth(this.WidthClass));
            if (this.Type == WidgetType.InfoBox)
            {
                widget.AppendFormat("<div class=\"info-box {0}\">", BackgroundColorClass);
                widget.AppendFormat("<span class=\"info-box-icon {1}\"><i class=\"{0}\"></i></span>",Icon, IconColorClass);
                widget.Append("<div class=\"info-box-content\">");
                widget.AppendFormat("<span class=\"info-box-text\">{0}</span>", this.Title);
                widget.AppendFormat("<span class=\"info-box-number\">{0}</span>", this.Value);
                widget.Append("</div>");
                widget.Append("</div>");
            }
            else if(this.Type == WidgetType.PanelBox)
            {
                widget.AppendFormat("<div class=\"card {0}\">", BackgroundColorClass);
                widget.Append("<div class=\"card-header\">");
                widget.AppendFormat("<h3 class=\"card-title\">{0}</h3>", this.Title);
                widget.Append("<div class=\"card-tools\">");
                widget.Append("<button type=\"button\" class=\"btn btn-tool\" data-card-widget=\"collapse\"> <i class=\"fas fa-minus\"></i></button>");
                widget.Append("<button type=\"button\" class=\"btn btn-tool\" data-card-widget=\"remove\"><i class=\"fas fa-times\"></i></button>");
                widget.Append("</div>");
                widget.Append("</div>");
                widget.Append("<div class=\"card-body p-0\">");
                widget.Append(layoutContent);
                widget.Append("</div>");
                widget.Append("</div>");
            }
            else
            {
                widget.Append(layoutContent);

            };
            widget.Append("</div>");
            return widget.ToString();
        }
        public IHtmlContent GetContent()
        {
            return new Microsoft.AspNetCore.Html.HtmlString(LayoutWidget(GetContentAsync().ConfigureAwait(false).GetAwaiter().GetResult().GetString()));
        }
        public IView PostData() {
            return null;
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

       
        #endregion
    }
}
