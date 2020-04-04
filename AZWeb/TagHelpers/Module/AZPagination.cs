using AZWeb.Common;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AZWeb.TagHelpers.Module
{
    [HtmlTargetElement("az-pagination")]
    public class AZPagination: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = "";
        [HtmlAttributeName("pagination")]
        public IPagination Pagination { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IQueryCollection query = Pagination.UrlVirtual;
            string pathReal = "";
            foreach (var key in query.Keys)
            {
                if(key!= "PageSize" && key!= "PageIndex"&&key!="time")
                pathReal = string.Format("{0}&{1}={2}", pathReal, key, HttpUtility.UrlEncode(query[key]));
            }
            pathReal = this.ViewContext.HttpContext.Request.Path.ToString() + "?" + pathReal;
            this.InputClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            htmlBuild.Append("<div class=\"row\">");
            htmlBuild.Append("<div class=\"col-sm-12 col-md-5\">");
            htmlBuild.Append("</div>");
            htmlBuild.Append("<div class=\"col-sm-12 col-md-7\">");
            htmlBuild.AppendFormat("<ul class=\"pagination {0} {1}\">",this.TagId, InputClass);
            htmlBuild.Append("<li style=\"padding: 3px; font-size: 20px; font-weight: 700;\">");
            htmlBuild.AppendFormat("Trang {0}/{1} Tổng {2}({3})",this.Pagination.PageIndex,this.Pagination.PageMax,this.Pagination.PageTotal,this.Pagination.PageTotalAll);
            htmlBuild.Append("</li>");
            htmlBuild.Append("<li style=\"padding:0px 5px;\">");
            htmlBuild.AppendFormat("<select class=\"form-control select2 az-change-ajax\" style=\"width: 100% \" name=\"PageSize\" az-href=\"{0}\">", pathReal);

            for (int index = 5; index < 50; index += 5) 
            {
                htmlBuild.AppendFormat("<option value=\"{0}\" name=\"PageSize_{0}\" {1} >{0}</option>", index, index==this.Pagination.PageSize? " selected=\"selected\"" : "");
            }

            htmlBuild.Append("</select>");

            htmlBuild.Append("</li>");
            htmlBuild.AppendFormat("<li class=\"paginate_button page-item previous {3}\"><a href=\"{0}&PageSize={2}&PageIndex={1}\" tabindex=\"0\" class=\"page-link  az-link\"><<</a></li>", pathReal, this.Pagination.PageIndex-1, this.Pagination.PageSize, this.Pagination.PageIndex <=1?"disabled":"");
            for (var i = 1; i < 10; i++) {
                htmlBuild.AppendFormat("<li class=\"paginate_button page-item {3}\"><a href=\"{0}&PageSize={2}&PageIndex={1}\"  tabindex=\"0\" class=\"page-link az-link\">{1}</a></li>",pathReal,i,this.Pagination.PageSize, this.Pagination.PageIndex==i? "active":"");
            }
            htmlBuild.AppendFormat("<li class=\"paginate_button page-item next {3}\"><a href=\"{0}&PageSize={2}&PageIndex={1}\"  tabindex=\"0\" class=\"page-link  az-link\">>></a></li>", pathReal, this.Pagination.PageIndex + 1, this.Pagination.PageSize, this.Pagination.PageIndex > 100 ? "disabled" : ""); 
            htmlBuild.Append("</ul>");
            htmlBuild.Append("</div>");
            htmlBuild.Append("</div>");

            this.AddJS("$(function(){ $('." + this.TagId + " select2').select2({theme: 'bootstrap4', width: 'resolve' }); });");
            output.Content.SetHtmlContent(htmlBuild.ToString());

        }
    }
}
