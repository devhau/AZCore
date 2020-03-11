using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZWeb.Common
{
    public class AZTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public IHtmlView HtmlResult { get => this.ViewContext.HttpContext.GetContetModule(); } 
    }
}
