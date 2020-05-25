using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Theme
{
    [HtmlTargetElement("az-style")]
    public class AZStyle : TagHelperBase
    {
        [HtmlAttributeName("link")]
        public string Link { get; set; }
        [HtmlAttributeName("cdn")]
        public string CDN { get; set; }
        [HtmlAttributeName("module")]
        public string Module { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            if (string.IsNullOrEmpty(this.Module))
            {
                var content = await output.GetChildContentAsync();
                this.AddCSS(content.GetContent(), Link, CDN);
            }
            else
            {
                this.AddCSS(this.GetContentFile(string.Format("css/{0}", this.Module)));
            }
            output.SuppressOutput();
        }
    }
}
