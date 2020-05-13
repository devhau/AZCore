using AZWeb.Extensions;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
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
        public virtual string LayoutWidget(string layoutContent) {
            StringBuilder widget = new StringBuilder();
            widget.Append("<div class=\"col-12 col-sm-6 col-md-3\">");
            if (this.Type == WidgetType.InfoBox)
            {
                widget.Append("<div class=\"info-box\">");
                widget.AppendFormat("<span class=\"info-box-icon bg-info elevation-1\"><i class=\"{0}\"></i></span>",Icon);
                widget.Append("<div class=\"info-box-content\">");
                widget.AppendFormat("<span class=\"info-box-text\">{0}</span>", this.Title);
                widget.AppendFormat("<span class=\"info-box-number\">{0}</span>", this.Value);
                widget.Append("</div>");
                widget.Append("</div>");
            }
            else if(this.Type == WidgetType.PanelBox)
            {
                widget.Append("<div class=\"card\">");
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
