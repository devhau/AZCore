using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZWeb.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-head",ParentTag ="az-html")]
    public class AZHead : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "head";

        }
    }
}
