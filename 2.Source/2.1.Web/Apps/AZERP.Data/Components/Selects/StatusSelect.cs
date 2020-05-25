using AZCore.Database;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-status-select")]
    public class StatusSelect : AZSelect<EntityStatus>
    {
    }
}
