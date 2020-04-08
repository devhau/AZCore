using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZWeb.TagHelpers.Html
{
    public class AZContent:AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            output.Content.SetHtmlContent(this.Html.Html.ToString());
        }
    }
}
