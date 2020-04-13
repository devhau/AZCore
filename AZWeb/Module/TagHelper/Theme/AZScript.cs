using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Theme
{
    [HtmlTargetElement("az-script")]
    public class AZScript : TagHelperBase
    {
        [HtmlAttributeName("link")]
        public string Link { get; set; }
        [HtmlAttributeName("cdn")]
        public string CDN { get; set; }
        [HtmlAttributeName("module")]
        public string Module { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(this.Module))
            {
                var content = await output.GetChildContentAsync();
                this.AddJS(content.GetContent(), Link, CDN);
            }
            else {
                this.AddJS(this.GetContentFile(string.Format("js/{0}",this.Module)));
            }
            output.SuppressOutput();
        }
    }
}
