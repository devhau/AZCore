using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-layout")]
    public class AZLayout : TagHelperBase
    {
        public Func<string, string> ScriptRandom { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            output.TagName = "div";
            if (ScriptRandom != null)
            {
                this.AddJS(ScriptRandom(this.TagId));
            }
            output.Attributes.Add(new TagHelperAttribute("class", string.Format(" {0} {1}",this.TagId,this.TagClass)));          
            var content = await output.GetChildContentAsync();
            htmlBuild.Append(content.GetContent());
        }
    }
}
