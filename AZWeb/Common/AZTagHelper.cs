using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace AZWeb.Common
{
    public class AZTagHelper : TagHelper
    {
        public string TagId { get; private set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public IHtmlView HtmlResult { get => this.ViewContext.HttpContext.GetContetModule(); }
        public override void Init(TagHelperContext context)
        {
            base.Init(context);
            this.TagId = string.Format("az{0}", Guid.NewGuid().ToString().Replace("-", ""));
        }
    }
}
