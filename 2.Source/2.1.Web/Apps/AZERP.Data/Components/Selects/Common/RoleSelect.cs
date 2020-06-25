using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-role-select")]
    public class RoleSelect : AZSelect<RoleService>
    {
    }
}
