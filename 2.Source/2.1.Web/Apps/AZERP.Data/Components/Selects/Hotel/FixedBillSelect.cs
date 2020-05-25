using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-fixed-bill-select")]
    public class FixedBillSelect : AZSelect<FixedBillService>
    {
    }
}