using AZCore.Database;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-status-select")]
    public class StatusSelect : AZSelect<EntityStatus>
    {
    }
}
