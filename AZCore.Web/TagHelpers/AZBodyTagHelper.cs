using AZCore.Web.Common;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.TagHelpers
{
    [HtmlTargetElement("az-body")]
    public class AZBodyTagHelper: AZTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            
            output.Content.SetHtmlContent(this.ViewContext.HttpContext.GetContetModule().Html.ToString()+"<br/>"+ this.ViewContext.HttpContext.Items[AZCoreWeb.KeyUrlVirtual]);
        }
    }
}

