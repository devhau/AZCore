using AZCore.Web.Common;
using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-theme")]
    public class AZTheme : AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            string html = ViewContext.HttpContext.RequestServices.GetRequiredService<ModulePortal>().GetTheme().GetHtml(); ;
            output.Content.SetHtmlContent(html);

        }
    }
}
