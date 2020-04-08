using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AZWeb.Module.Common
{
    public class TagHelperBase: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string TagId { get; private set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
    }
}
