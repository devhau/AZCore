﻿using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-job-nature-select")]
    public class JobNatureSelect : AZSelect<JobNature>
    {
    }
}
