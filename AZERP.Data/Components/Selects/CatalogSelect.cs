using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-catalog-select")]
    public class CatalogSelect : AZSelect<CatalogService>
    {
    }
}
