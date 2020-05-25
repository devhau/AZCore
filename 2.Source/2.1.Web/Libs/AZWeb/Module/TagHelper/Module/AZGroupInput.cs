using AZCore.Extensions;
using AZWeb.Module.Common;
using AZWeb.Module.TagHelper.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-group-input")]
    public class AZGroupInput : TagHelperBase
    {
        public string GroupName { get; set; } 
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            string GroupInput = "";
            if (this.HttpContext.Items.ContainsKey(AZInput.GroupInput)) {
                GroupInput = this.HttpContext.Items[AZInput.GroupInput].ToString();
            }
            this.HttpContext.Items[AZInput.GroupInput] = GroupName;
            var content =await output.GetChildContentAsync();
            htmlBuild.Append(content.GetContent());
            this.HttpContext.Items.Remove(AZInput.GroupInput);
            if (!GroupInput.IsNullOrEmpty()) {
                this.HttpContext.Items[AZInput.GroupInput] = GroupInput;
            }
        }
    }
}
