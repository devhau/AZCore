using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-switch-model")]
    public class AZSwitchModel : AZSwitch, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            
            this.BindModel();
            if (true.Equals(this.InputValue))
            {
                this.Attr += " checked='true'";
            }
            else
            {
                this.InputValue = true;
            }
        }
    }

    [HtmlTargetElement("az-switch")]
    public class AZSwitch : AZInput
    {
        public string On { get; set; } = "Bật";
        public string Off { get; set; } = "Tắt";
        public string size { get; set; } = "small";
        public override void Init(TagHelperContext context)
        {
            base.Init(context);
            if (!string.IsNullOrEmpty(TagClass)&&TagClass.IndexOf("form-control")>=0)
            {
                TagClass=TagClass.Replace(" form-control"," ");
            }
        }
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" data-bootstrap-switch data-off-text=\"{7}\" data-on-text=\"{8}\" data-off-color=\"danger\" data-on-color=\"success\" data-size=\""+size+"\">", "checkbox", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName,Off,On);
            if(AddJs) this.AddJS($"$('.{TagId}').bootstrapSwitch('state', $('.{TagId}').prop('checked'));");
        }
    }
   
}
