﻿using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-company-info-select")]
    public class CompanyWorkerSelect : AZSelect<CompanyInfoService>
    {
    }
}
