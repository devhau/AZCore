using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Html
{
    [HtmlTargetElement("az-script")]
    public class AZScript : AZTagHelper
    {
        [HtmlAttributeName("link")]
        public string Link { get; set; }
        [HtmlAttributeName("cdn")]
        public string CDN { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            this.Html.JS.Add(new Configs.ContentTag() { Code = content.GetContent(),CDN=this.CDN,Link=this.Link });
            output.SuppressOutput();
        }
    }
}
