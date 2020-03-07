using AZWeb.Common;
using AZWeb.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers
{
    [HtmlTargetElement("az-table")]
    public class AZTable : AZTagHelper
    {
        [HtmlAttributeName("table")]
        public TableTag Table { get; set; }
        [HtmlAttributeName("data")]
        public object Data { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Table = new TableTag();
            Table.Columns = new List<ColumnTag>();
            Table.Columns.Add(new ColumnTag()
            {

                Title = "Họ Tên"

            });
            Table.Columns.Add(new ColumnTag()
            {

                Title = "Địa Chỉ"

            }); 
            Table.Columns.Add(new ColumnTag()
            {

                Title = "Ghi Chú"

            });
            Table.Columns.Add(new ColumnTag()
            {

                Title = "Trạng thái"

            });

            output.TagName = "";
            StringBuilder htmlTable = new StringBuilder();
            //<table class=\"table table-bordered table-hover dataTable\" role=\"grid\">
            htmlTable.Append("<table class=\"table table-bordered table-hover dataTable\" role=\"grid\">");
            this.RenderHeader(htmlTable);
            this.RenderBody(htmlTable);
            this.RenderBottom(htmlTable);
            htmlTable.Append("</table>");
            output.Content.SetHtmlContent(htmlTable.ToString());
        }
        private void RenderHeader(StringBuilder htmlTable)
        {
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr>");
            if (Table.IsIndex) {
                htmlTable.Append("<th>");
                htmlTable.Append("#");
                htmlTable.Append("</th>");
            }

            foreach (var item in Table.Columns)
            {
                htmlTable.Append("<th class=\"sorting_asc\" tabindex=\"0\" rowspan =\"1\" colspan =\"1\" aria-sort=\"ascending\" >");
                htmlTable.Append(item.Title);
                htmlTable.Append("</th>");
            }

            if (Table.IsEdit)
            {
                htmlTable.Append("<th>");
                htmlTable.Append("Sửa");
                htmlTable.Append("</th>");
            }
            if (Table.IsDelete)
            {
                htmlTable.Append("<th>");
                htmlTable.Append("Xóa");
                htmlTable.Append("</th>");
            }


            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
        }
        private void RenderBody(StringBuilder htmlTable)
        {
            htmlTable.Append("<tbody>");
            htmlTable.Append("</tbody>");
        }
        private void RenderBottom(StringBuilder htmlTable)
        {
        }
    }
}
