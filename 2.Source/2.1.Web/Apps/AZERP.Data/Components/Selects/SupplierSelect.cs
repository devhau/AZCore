using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-supplier-select")]
    public class SupplierSelect : AZSelect<SupplierService>
    {
    }
}
