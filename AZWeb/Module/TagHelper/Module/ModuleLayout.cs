﻿using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{

    [HtmlTargetElement("az-module-layout")]
    public class ModuleLayout : TagHelperBase
    {
        public Func<string, string> ScriptRandom { get; set; }
        public List<ButtonInfo> Buttons { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            output.TagName = "div";
            if (ScriptRandom != null)
            {
                this.AddJS(ScriptRandom(this.TagId));
            }
            
            if (HttpContext.Request.Query.ContainsKey("ActionType") && HttpContext.Request.Query["ActionType"] == "popup")
            {
                output.Attributes.Add(new TagHelperAttribute("class", "module-popup " + this.TagId));
                return ;
            }
          
            var content = await output.GetChildContentAsync();
            htmlBuild.AppendFormat("<div class=\"az-module-layout {0} {1}\" {2}>", this.TagId,this.TagClass,this.Attr);
            htmlBuild.AppendFormat("<div class=\"az-module-header row\"><h4 class=\"col\" style=\"padding:2px 0px 2px 7px;;margin-bottom:0px;font-weight:700;\">{0}</h4>", this.Html.Title);
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
