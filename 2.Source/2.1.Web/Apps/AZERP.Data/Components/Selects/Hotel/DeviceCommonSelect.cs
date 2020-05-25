using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-device-common-select")]
    public class DeviceCommonSelect : AZSelect<DeviceCommonService>
    {
    }
}