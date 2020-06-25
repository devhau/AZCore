using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-company-worker-select")]
    public class CompanyWorkerSelect : AZSelect<CompanyWorkerService>
    {
    }
}
