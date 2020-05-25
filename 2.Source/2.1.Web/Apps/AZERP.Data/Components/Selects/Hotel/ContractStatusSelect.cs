using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components
{
    [HtmlTargetElement("az-contract-status-select")]
    public class ContractStatusSelect : AZSelect<TypeOfContractStatus>
    {
    }
}
