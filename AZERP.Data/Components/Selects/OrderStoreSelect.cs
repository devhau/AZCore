using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-store-status-select")]
    public class OrderStoreSelect : AZSelect<PurchaseOrderImport>
    {
    }
}
