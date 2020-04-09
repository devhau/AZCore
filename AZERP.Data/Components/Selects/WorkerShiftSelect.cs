using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-work-shift-select")]
    public class WorkShiftSelect : AZSelect<EnumWorkShift>
    {
    }
}
