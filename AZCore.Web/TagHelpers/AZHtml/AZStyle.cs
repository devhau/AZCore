using AZCore.Web.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZCore.Web.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-style")]
    public class AZStyle : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

        }
    }
}
