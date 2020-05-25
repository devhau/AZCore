using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{

    [HtmlTargetElement("az-module-layout")]
    public class AZModuleLayout : TagHelperBase
    {
        public IEnumerable<ButtonInfo> Buttons { get; set; }
        public string Icon { get; set; } = "fas fa-home";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            output.TagName = "";
          
            if (string.IsNullOrEmpty(this.Html.Icon)) this.Html.Icon = Icon;
            var content = await output.GetChildContentAsync();
            htmlBuild.AppendFormat("<div class=\"az-module-layout {0} \" {1}>", this.TagClass,this.Attr);
            htmlBuild.AppendFormat("<div class=\"az-module-header row\"><div class=\"col\" ><h4 class=\"title\" style=\"padding:2px 0px 2px 7px;;margin-bottom:0px;font-weight:700;\"><i class=\"{1}\"></i> {0}</h4></div>", this.Html.Title, Icon);
            htmlBuild.Append("<div >");
            if (Buttons != null) {
                foreach (var item in Buttons) {
                    if(this.HasPermission(item.PermisisonCode))
                    htmlBuild.Append(item.ToString());
                }
            }
            htmlBuild.Append("</div></div>");
            htmlBuild.Append("<div class=\"az-module-body\">");
            htmlBuild.Append(content.GetContent());
            htmlBuild.Append("</div>");
            htmlBuild.Append("</div>");
        }
    }
}
