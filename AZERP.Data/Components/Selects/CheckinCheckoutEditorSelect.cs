using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-checkin-checkout-editor-select")]
    public class CheckinCheckoutEditorSelect : AZSelect<CheckinCheckoutEditor>
    {
    }
}
