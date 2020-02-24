using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-layout")]
    public class AZLayout: AZTagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "";
            var content = await output.GetChildContentAsync();
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<div class=\"az-wrapper\">");
            htmlBuilder.Append("<nav class=\"navbar navbar-expand fixed-top az-top-header\">");              
            htmlBuilder.Append("<div class=\"container-fluid\">");
            htmlBuilder.Append("<div class=\"az-navbar-header\"><a class=\"navbar-brand\" href=\"/\"></a></div>");
            htmlBuilder.Append("<div class=\"menu-top\"></div>");
            htmlBuilder.Append("<div class=\"be-right-navbar\">");

            htmlBuilder.Append("</div>");
            htmlBuilder.Append("</nav>");
            htmlBuilder.Append(content.GetContent());
            
            htmlBuilder.Append("</div>");
            output.Content.SetHtmlContent(htmlBuilder.ToString());
        }
    }
}
