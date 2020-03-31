using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Diagnostics;
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
                try
                {
                    var memberExpression = this.Func.Body as MemberExpression ?? ((UnaryExpression)this.Func.Body).Operand as MemberExpression;
                    this.InputName = memberExpression.Member.Name;
                    if (string.IsNullOrEmpty(this.InputId))
                        this.InputId = string.Format("Input{0}", this.InputName);
                    if (Model != null)
                    {
                        if(this.LenCode>0)
                            Attr += " disabled ";
                        this.InputValue = this.Func.Compile()(Model);

                        if(memberExpression.Type == typeof(bool)|| memberExpression.Type == typeof(bool?))
                        {
                            if ((bool)this.InputValue == true) 
                            {
                                this.Attr += " checked ";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            if (this.InputType == AZInputType.checkbox)
            {
                this.InputValue = true;
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
        [HtmlAttributeName("len-code")]
        public int LenCode { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (LenCode > 0 ) {
                if(InputValue == null)
                    InputValue = Guid.NewGuid().ToString();
                if (this.Attr==null || !this.Attr.Contains("disabled")) {
                    //readonly

                    Attr += " readonly ";
                }
            }
            if (InputType == AZInputType.checkbox) {
                this.InputClass = "";
            }
            this.InputClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            if (InputType == AZInputType.checkbox)
            {
                htmlBuild.Append("<div class=\"icheck-primary d-inline\">");
            }
            if (!string.IsNullOrEmpty(InputLabel)&& InputType != AZInputType.checkbox)
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">",InputType,InputClass,InputId,InputPlaceholder, Attr, InputValue.IsNullOrEmpty()?"": string.Format("value =\"{0}\"", InputValue), InputName);

            if (InputType == AZInputType.checkbox)
            {
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
                htmlBuild.Append("</div>");
            }
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
