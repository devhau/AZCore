using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-job-nature-label")]
    public class JobNatureLabel : AZLabel<JobNature>
    {
    }
}
