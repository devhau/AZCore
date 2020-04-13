using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-module-layout")]
    public class ModuleLayout : TagHelperBase
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
                output.TagName = "div";
            if (HttpContext.Request.Query.ContainsKey("ActionType") && HttpContext.Request.Query["ActionType"] == "popup")
            {
                output.Attributes.Add(new TagHelperAttribute("class", "module-popup"));
                return;
            }
                var content = await output.GetChildContentAsync();
                StringBuilder htmlBuild = new StringBuilder();
                htmlBuild.Append("<div class=\"az-module-layout\">");
                htmlBuild.AppendFormat("<div class=\"az-module-header\"><h4 style=\"padding:2px 0px 2px 7px;;margin-bottom:0px;font-weight:700;\">{0}</h4></div>", this.Html.Title);
                htmlBuild.Append("<div class=\"az-module-body\">");
                htmlBuild.Append(content.GetContent());
                htmlBuild.Append("</div>");
                htmlBuild.Append("</div>");
                output.Content.SetHtmlContent(htmlBuild.ToString());
        }
        
    }
}
