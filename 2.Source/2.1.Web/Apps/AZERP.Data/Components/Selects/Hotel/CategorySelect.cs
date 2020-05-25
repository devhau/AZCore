using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-category-select")]
    public class CategorySelect : AZSelect<CategoryService>
    {
    }
}
