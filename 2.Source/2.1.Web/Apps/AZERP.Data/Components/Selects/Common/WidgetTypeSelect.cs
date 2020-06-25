using AZWeb.Module.Common;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-widget-type-select")]
    public class WidgetTypeSelect : AZSelect<WidgetType>
    {
    }
}
