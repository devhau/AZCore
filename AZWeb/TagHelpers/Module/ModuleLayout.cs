using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Module
{
    [HtmlTargetElement("az-module-layout")]
    public class ModuleLayout : AZTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";

            lock (TagLock)
            {
                var content = output.GetChildContentAsync();
                content.Wait();
                var contentHtml = content.Result;
                StringBuilder htmlBuild = new StringBuilder();
                htmlBuild.Append("<div class=\"az-module-layout\">");
                htmlBuild.AppendFormat("<div class=\"az-module-header\"><h4 style=\"padding:2px 0px 2px 7px;;margin-bottom:0px;font-weight:700;\">{0}</h4></div>", this.Html.Title);
                htmlBuild.Append("<div class=\"az-module-body\">");
                htmlBuild.Append(contentHtml.GetContent());
                htmlBuild.Append("</div>");
                htmlBuild.Append("</div>");
                output.Content.Clear();
                output.Content.SetHtmlContent(htmlBuild.ToString());
            }
        }
        
    }
}
