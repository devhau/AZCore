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
    [HtmlTargetElement("az-model-select")]
    public class AZModelSelect : AZSelect
    { 
        public object Model { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            base.Process(context, output);
        }
    }
    [HtmlTargetElement("az-select")]
    public class AZSelect: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
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
            this.InputClass += " "+ this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            if(!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<select class=\"{0}\" name=\"{1}\" {2} {3}>", InputClass, InputName,string.IsNullOrEmpty(InputId)?"":string.Format("id=\"{0}\"", InputId), Attr);
            htmlBuild.Append("</select>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }

  
}
