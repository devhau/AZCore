using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-filter-date2-select")]
    public class FilterDateSelect : AZSelect<FilterDate2>
    {
    }
}
