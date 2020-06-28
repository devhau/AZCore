﻿using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Components.Labels
{
    [HtmlTargetElement("az-month-label")]
    public class MonthLabel : AZLabel<Month>
    {
    }
}
