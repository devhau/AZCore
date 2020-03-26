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
            htmlBuild.Append(content.GetContent());
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
        
    }
}
