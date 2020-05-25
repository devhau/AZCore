using AZCore.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    public class ButtonInfo 
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string CMD { get; set; }
        public string ClassName { get; set; }
        public string PermisisonCode { get; set; }
        public string Link { get; set; }
        public string ModalSize { get; set; }
        public string Html { get; set; }
        public override string ToString()
        {
            if (!Html.IsNullOrEmpty()) return Html;
            string IconText = string.IsNullOrEmpty(Icon) ? "" : $" <i class='{Icon}'></i> ";
            if (string.IsNullOrEmpty(Link)) {
                return ($"<button type=\"button\" id=\"{Id}\" title=\"{Text}\" class=\"btn az-btn {ClassName}\" data-cmd-key=\"{CMD}\" >{IconText}<label>{Text}</label></button>");
            }
            return $"<a href=\"{Link}\" id=\"{Id}\" class=\"{ClassName}\" title=\"{Text}\" data-cmd-key=\"{CMD}\" modal-size=\"{ModalSize}\" >{IconText}<label>{Text}</label></a>";

        }
    }
    [HtmlTargetElement("az-button")]
    public class AZButton : TagHelperBase
    {
        [HtmlAttributeName("id")]
        public string ButtonId { get; set; }
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
