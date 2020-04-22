using AZERP.Data.Entities.Hotel;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-area-select")]
    public class AreaSelect : AZSelect<AreaService>
    {
    }
}