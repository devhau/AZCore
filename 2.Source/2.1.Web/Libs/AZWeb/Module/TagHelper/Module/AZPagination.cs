using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-pagination")]
    public class AZPagination : TagHelperBase
    {
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = "";
        [HtmlAttributeName("pagination")]
        public IPagination Pagination { get; set; }
        [HtmlAttributeName("page-show")]
        public int PageShow { get; set; } = 7;
        [HtmlAttributeName("list-page-size")]
        public string ListPageSize { get; set; } = "10,20,50,100,200,500,1000";
        public string FormatPage { get; set; } = "{0}/{1}/{2}({3})";
        public string LinkClass { get; set; } = "link-ajax";


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            var query = QueryHelpers.ParseQuery(Pagination.UrlVirtual.Value);
            string pathReal = "";
            foreach (var key in query.Keys)
            {
                if (key != "PageSize" && key != "PageIndex" && key != "rows" && key != "time")
                    pathReal = string.Format("{0}&{1}={2}", pathReal, key, HttpUtility.UrlEncode(query[key]));
            }
            pathReal = this.ViewContext.HttpContext.Request.Path.ToString() + "?" + pathReal;
            htmlBuild.Append("<div class=\"az-pagination\">");
            htmlBuild.AppendFormat("<ul class=\"pagination {0} {1}\">", this.TagId, InputClass);
            htmlBuild.Append("<li style=\"padding:0px 5px;\">");
            htmlBuild.Append("<form>");
            foreach (var key in query.Keys)
            {
                if (key != "PageSize" && key != "PageIndex" && key!= "rows" && key != "time")
                    htmlBuild.AppendFormat("<input type='hidden' name='{0}' value='{1}'/>", key, query[key]);
            //    pathReal = string.Format("{0}&{1}={2}", pathReal, key, HttpUtility.UrlEncode(query[key]));
            }
            htmlBuild.AppendFormat("<select class=\"form-control select2\" onchange=\"this.form.submit()\" style=\"width: 100% \" name=\"rows\" az-href=\"{0}\">", pathReal);
            foreach (var item in ListPageSize.Split(","))
            {
                int PageSize = 0;
                if (int.TryParse(item, out PageSize))
                {
                    htmlBuild.AppendFormat("<option value=\"{0}\" name=\"PageSize_{0}\" {1} >{0}</option>", PageSize, PageSize == this.Pagination.PageSize ? " selected=\"selected\"" : "");

                }
            }
            htmlBuild.Append("</select>");
            htmlBuild.Append("</form>");
            htmlBuild.Append("</li>");
            htmlBuild.AppendFormat("<li class=\"paginate_button page-item previous {3}\"><a href=\"{0}&rows={2}&PageIndex={1}\" tabindex=\"0\" class=\"page-link {4}\"><<</a></li>", pathReal, this.Pagination.PageIndex - 1, this.Pagination.PageSize, this.Pagination.PageIndex <= 1 ? "disabled" : "", LinkClass);

            int startIndex = 0;
            int endIndex = 0;
            int IndexCenter = (int)Math.Ceiling((decimal)this.PageShow / 2);

            if (this.Pagination.PageIndex - IndexCenter <= 0)
            {
                startIndex = 0;
            }
            else
            {
                startIndex = this.Pagination.PageIndex - IndexCenter;
            }
            if (startIndex + this.PageShow >= this.Pagination.PageMax)
            {
                endIndex = this.Pagination.PageMax - 1;
                startIndex = this.Pagination.PageMax - this.PageShow - 1;
                if (startIndex <= 0) startIndex = 0;
            }
            else
            {
                endIndex = this.PageShow + startIndex - 1;
            }
            for (var i = startIndex; i <= endIndex; i++)
            {
                htmlBuild.AppendFormat("<li class=\"paginate_button page-item {3}\"><a href=\"{0}&rows={2}&PageIndex={1}\"  tabindex=\"0\" class=\"page-link {4}\">{1}</a></li>", pathReal, i + 1, this.Pagination.PageSize, this.Pagination.PageIndex == i + 1 ? "active" : "", LinkClass);
            }
            htmlBuild.AppendFormat("<li class=\"paginate_button page-item next {3}\"><a href=\"{0}&rows={2}&PageIndex={1}\"  tabindex=\"0\" class=\"page-link  {4}\">>></a></li>", pathReal, this.Pagination.PageIndex + 1, this.Pagination.PageSize, this.Pagination.PageIndex >= this.Pagination.PageMax ? "disabled" : "", LinkClass);
            htmlBuild.Append("<li style=\"padding: 3px; font-size: 18px; font-weight: 500;\">");
            htmlBuild.AppendFormat(FormatPage, this.Pagination.PageIndex, this.Pagination.PageMax, this.Pagination.PageTotal, this.Pagination.PageTotalAll);
            htmlBuild.Append("</li>");
            htmlBuild.Append("</ul>");
            htmlBuild.Append("</div>");

            this.AddJS(" $('." + this.TagId + " select2').select2({theme: 'bootstrap4', width: 'resolve' });");
            output.Content.SetHtmlContent(htmlBuild.ToString());
            await Task.CompletedTask;
        }
    }
}
