using AZCore.Web.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.TagHelpers
{
    [HtmlTargetElement("az-hello")]
    public class AZHelloTagHelper : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            output.Content.SetHtmlContent("Hello Word");
        }
    }
}
