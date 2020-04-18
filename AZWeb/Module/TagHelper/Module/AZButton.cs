using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-button")]
    public class AZButton : TagHelperBase
    {
        [HtmlAttributeName("id")]
        public string ButtonId { get; set; }
        [HtmlAttributeName("class")]
        public override string TagClass { get; set; } = "";
        [HtmlAttributeName("text")]
        public string Text { get; set; }
        [HtmlAttributeName("icon")]
        public string Icon { get; set; }
        [HtmlAttributeName("cmd-key")]
        public string CMD { get; set; }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            string IconText = string.IsNullOrEmpty(Icon) ? "" : $" <i class='{Icon}'></i> ";
            htmlBuild.Append($"<button type=\"button\" id=\"{ButtonId}\" class=\"btn az-btn {TagClass}\" data-cmd-key=\"{CMD}\" >{IconText}{Text}</button>");
            return Task.CompletedTask;
        }
    }
}
