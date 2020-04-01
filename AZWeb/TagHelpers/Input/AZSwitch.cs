using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.TagHelpers.Input
{
    [HtmlTargetElement("az-switch-model")]
    public class AZSwitchModel : AZSwitch, IAZModelInput
    {
        public IEntityModel Model { get; set; }
        public Expression<Func<IEntityModel, object>> Func { get; set; }
        protected override void InitData()
        {
            
            this.BindModel();
            if (true.Equals(this.InputValue))
            {
                this.Attr += " checked";
            }
            else
            {
                this.InputValue = true;
            }
            this.InputClass = "";
        }
    }

    [HtmlTargetElement("az-switch")]
    public class AZSwitch : AZInput
    {
        public string On { get; set; } = "Bật";
        public string Off { get; set; } = "Tắt";
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label><br/>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" data-bootstrap-switch data-off-text=\"{7}\" data-on-text=\"{8}\" data-off-color=\"danger\" data-on-color=\"success\">", "checkbox", InputClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName,Off,On);

            this.AddJS("$(function(){ $('." + this.TagId + "').bootstrapSwitch('state', $('." + this.TagId + "').prop('checked'));; });");
        }
    }
   
}
