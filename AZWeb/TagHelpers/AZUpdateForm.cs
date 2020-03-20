using AZWeb.Common;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers
{
    [HtmlTargetElement("az-update-form")]
    public class AZUpdateForm: AZTagHelper
    {
        public object Data { get; set; }
        [HtmlAttributeName("columns")]
        public List<TableColumnAttribute> Columns { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            htmlBuild.Append("<div class=\"row\">");
            foreach (var item in this.Columns) {
                htmlBuild.AppendFormat(" <div class=\"form-group col-md-6\"><label for=\"input{0}\">{1}</label><input type=\"email\" name=\"{0}\" class=\"form-control\" id=\"input{0}\" placeholder=\"{1}\"></div>",item.FieldName,item.Title);
            }
            htmlBuild.Append("</div>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }
}
