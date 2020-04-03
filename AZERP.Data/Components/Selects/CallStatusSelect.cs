using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-call-status-select")]
    public class CallStatusSelect : AZSelect<EnumCallStatus>
    {
    }
}
