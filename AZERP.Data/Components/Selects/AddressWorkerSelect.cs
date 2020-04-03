using AZCore.Database;
using AZERP.Data.Enums;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-address-worker-select")]
    public class AddressWorkerSelect : AZSelect<EnumAddressWorker>
    {
    }
}
