using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Html
{
    [HtmlTargetElement("az-style")]
    public class AZStyle : AZTagHelper
    {
        [HtmlAttributeName("link")]
        public string Link { get; set; }
        [HtmlAttributeName("cdn")]
        public string CDN { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            this.HtmlResult.CSS.Add(new Configs.ContentTag() { Code = content.GetContent(), CDN = this.CDN, Link = this.Link });
            output.SuppressOutput();
        }
    }
}
