using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{

    [HtmlTargetElement("az-day-of-week-select")]
    public class DayOfWeekSelect : AZSelect<DayOfWeek>
    {
        
    }
}
