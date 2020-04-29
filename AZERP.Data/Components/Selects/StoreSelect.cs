using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-store-select")]
    public class StoreSelect : AZSelect<StoreService>
    {
    }
}
