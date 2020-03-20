using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.TagHelpers.Input
{
    [HtmlTargetElement("az-model-input")]
    public class AZModelInput : AZInput 
    { 
        public IEntityModel Model { get; set; }
        public Expression<Func<IEntityModel, object>> Func { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Func != null) {
                this.InputName = this.Func.Body.As<MemberExpression>().Member.Name;
                if (string.IsNullOrEmpty(this.InputId))
                    this.InputId = string.Format("Input{0}",this.InputName);
                if (Model != null) {
                    this.InputValue = this.Func.Compile()(Model);
                }
            }
            base.Process(context, output);
        }
    }
    [HtmlTargetElement("az-input")]
    public class AZInput: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("type")]
        public AZInputType InputType { get; set; } = AZInputType.text;
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = "form-control";
        [HtmlAttributeName("id")]
        public string InputId { get; set; }
        [HtmlAttributeName("name")]
        public string InputName { get; set; }
        [HtmlAttributeName("label")]
        public string InputLabel { get; set; }
        [HtmlAttributeName("placeholder")]
        public string InputPlaceholder { get; set; }
        [HtmlAttributeName("value")]
        public object InputValue { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            if(!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} value=\"{5}\" name=\"{6}\">",InputType,InputClass,InputId,InputPlaceholder, Attr, InputValue, InputName);
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }

    public enum AZInputType
    {
        button,
        checkbox,
        color,
        date,
        email,
        file,
        hidden,
        image,
        month,
        number,
        password,
        radio,
        range,
        reset,
        search,
        submit,
        tel,
        text,
        time,
        url,
        week,
    }
}
