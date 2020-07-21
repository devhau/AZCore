using AZCore.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Theme
{
    [HtmlTargetElement("az-content-header")]
    public class AZContentHeader : TagHelperBase
    {
        public string TextHome { get; set; } = "Home";
        public string LinkHome { get; set; } = "/";
        public string TitleContent { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            htmlBuild.Append("<!-- Content Header (Page header) -->");
            htmlBuild.Append("<div class='content-header'>");
            htmlBuild.Append("    <div class='container-fluid'>");
            htmlBuild.Append("        <div class='row mb-2'>");
            htmlBuild.Append("            <div class='col-sm-6'>");
            htmlBuild.AppendFormat("                <h1 class='m-0 text-dark'>{0}</h1>",TitleContent.IsNullOrEmpty()?Title:TitleContent);
            htmlBuild.Append("            </div><!-- /.col -->");
            htmlBuild.Append("            <div class='col-sm-6'>");
            htmlBuild.Append("                <ol class='breadcrumb float-sm-right'>");
            htmlBuild.AppendFormat("                    <li class='breadcrumb-item'><a href='{0}'>{1}</a></li>",this.LinkHome,this.TextHome);
            htmlBuild.AppendFormat("                    <li class='breadcrumb-item active'>{0}</li>", TitleContent.IsNullOrEmpty() ? Title : TitleContent);
            htmlBuild.Append("                </ol>");
            htmlBuild.Append("            </div><!-- /.col -->");
            htmlBuild.Append("        </div><!-- /.row -->");
            htmlBuild.Append("    </div><!-- /.container-fluid -->");
            htmlBuild.Append("</div>");
            htmlBuild.Append("<!-- /.content-header -->");

            await Task.CompletedTask;
        }
    }
}
