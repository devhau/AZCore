using AZWeb.Common;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Module
{
    [HtmlTargetElement("az-pagination")]
    public class AZPagination: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = "form-control";
        [HtmlAttributeName("pagination")]
        public IPagination Pagination { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            this.InputClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            htmlBuild.Append("<div class=\"row\">");
            htmlBuild.Append("<div class=\"col-sm-12 col-md-5\">");
            htmlBuild.Append("</div>");
            htmlBuild.Append("<div class=\"col-sm-12 col-md-7\">");
            htmlBuild.Append("<ul class=\"pagination\">");
            htmlBuild.Append("<li>Test</li>");
            htmlBuild.Append("<li class=\"paginate_button page-item previous disabled\" id=\"example2_previous\"><a href=\"#\" aria-controls=\"example2\" data-dt-idx=\"0\" tabindex=\"0\" class=\"page-link\">Previous</a></li>");
            for (var i = 0; i < 10; i++) {
                htmlBuild.Append("<li class=\"paginate_button page-item \"><a href=\"#\" aria-controls=\"example2\" data-dt-idx=\"2\" tabindex=\"0\" class=\"page-link\">"+ i + "</a></li>");
            }
            htmlBuild.Append("<li class=\"paginate_button page-item next\" id=\"example2_next\"><a href=\"#\" aria-controls=\"example2\" data-dt-idx=\"7\" tabindex=\"0\" class=\"page-link\">Next</a></li>"); 
            htmlBuild.Append("</ul>");
            htmlBuild.Append("</div>");
            htmlBuild.Append("</div>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
        }
    }
}
