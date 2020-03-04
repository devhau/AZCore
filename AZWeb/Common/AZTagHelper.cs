using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common
{
    public class AZTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public IView HtmlResult { get => this.ViewContext.HttpContext.GetContetModule(); } 
    }
}
