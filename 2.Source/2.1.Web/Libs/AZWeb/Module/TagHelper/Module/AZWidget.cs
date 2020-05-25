using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    public enum WType{
        Card,
        Box,
        Full
}
    public class AZWidget : TagHelperBase
    {
        public WType Type { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            var content = await output.GetChildContentAsync();
            htmlBuild.Append("");
        }
    }
}
