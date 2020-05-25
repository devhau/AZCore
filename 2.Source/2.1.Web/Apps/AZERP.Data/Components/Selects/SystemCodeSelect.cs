using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-system-code-select")]
    public class SystemCodeSelect : AZSelect<SystemCode>
    {
    }
}
