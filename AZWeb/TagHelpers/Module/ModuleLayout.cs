using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZWeb.Extensions;

namespace AZWeb.TagHelpers.Module
{
    [HtmlTargetElement("az-module-layout")]
    public class ModuleLayout : AZTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            StringBuilder htmlBuild = new StringBuilder();
            var content = await output.GetChildContentAsync();
            htmlBuild.Append("<div class=\"az-module-layout\">");
            htmlBuild.AppendFormat("<div class=\"az-module-header\"><h4 style=\"padding:2px 0px 2px 7px;;margin-bottom:0px;font-weight:700;\">{0}</h4>", this.Html.Title);
            htmlBuild.Append(content.GetContent());
            htmlBuild.Append("</div>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
        
    }
}
