using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-body", ParentTag = "az-html")]
    public class AZBody : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "body";

        }
    }
}
