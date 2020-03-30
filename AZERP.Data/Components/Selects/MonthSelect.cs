using AZERP.Data.Enums;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-month-select")]
    public class MonthSelect : AZSelect<EnumMonth>
    {
    }
}
