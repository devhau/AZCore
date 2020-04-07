using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-company-worker-select")]
    public class CompanyWorkerSelect : AZSelect<CompanyWorkerService>
    {
    }
}
