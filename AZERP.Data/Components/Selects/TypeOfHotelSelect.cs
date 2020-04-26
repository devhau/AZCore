using AZERP.Data.Entities;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AZERP.Data.Components.Selects
{
    [HtmlTargetElement("az-typeOfHotel-select")]
    public class TypeOfHotelSelect : AZSelect<TypeOfHotelService>
    {
    }
}