using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-link")]
    public class AZLink : TagHelperBase
    {
        [HtmlAttributeName("id")]
        public string LinkId { get; set; }
        [HtmlAttributeName("text")]
        public string Text { get; set; }
        [HtmlAttributeName("icon")]
        public string Icon { get; set; }
        [HtmlAttributeName("href")]
        public string Link { get; set; }
        [HtmlAttributeName("cmd-key")]
        public string CMD { get; set; }
        [HtmlAttributeName("modal-size")]
        public string ModalSize { get; set; }
        public override void Init(TagHelperContext context)
        {
            if (string.IsNullOrEmpty(TagClass))
                TagClass = "az-link";
            base.Init(context);
        }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            string IconText = string.IsNullOrEmpty(Icon) ? "" : $" <i class='{Icon}'></i> ";
            htmlBuild.Append($"<a href=\"{Link}\" id=\"{LinkId}\" class=\"{TagClass}\" data-cmd-key=\"{CMD}\" modal-size=\"{ModalSize}\" >{IconText}{Text}</a>");
            return Task.CompletedTask;
        }
    }
}
