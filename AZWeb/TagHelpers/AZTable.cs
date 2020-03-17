using AZCore.Database;
using AZWeb.Common;
using AZWeb.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

                Title = "Họ Tên",
                FieldName = "Fullname",
                Width="200px;"
            }) ;
            Table.Columns.Add(new ColumnTag()
            {

                Title = "Địa Chỉ",
                FieldName = "Address"

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
            htmlTable.Append("<table class=\"table table-bordered table-hover dataTable\" role=\"grid\">");
            this.RenderHeader(htmlTable, Table);
            this.RenderBody(htmlTable, Table,Data);
            this.RenderBottom(htmlTable, Table);
            htmlTable.Append("</table>");
            output.Content.SetHtmlContent(htmlTable.ToString());
        }
        private void RenderHeader(StringBuilder htmlTable, TableTag Table)
        {
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr>");
            if (Table.IsIndex) {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("#");
                htmlTable.Append("</th>");
            }

            foreach (var item in Table.Columns)
            {
                htmlTable.Append("<th class=\"sorting_asc\" tabindex=\"0\" rowspan =\"1\" colspan =\"1\" aria-sort=\"ascending\" width=\""+ item.Width + "\">");
                htmlTable.Append(item.Title);
                htmlTable.Append("</th>");
            }

            if (Table.IsEdit)
            {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("Sửa");
                htmlTable.Append("</th>");
            }
            if (Table.IsDelete)
            {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("Xóa");
                htmlTable.Append("</th>");
            }


            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
        }
        private void RenderBody(StringBuilder htmlTable, TableTag Table,object Data)
        {
            int IndexRow = 0;
            
            htmlTable.Append("<tbody>");
            if (Data is DataTable)
            {
                var _dataTable = (DataTable)Data;
                foreach (var item in _dataTable.Rows)
                {
                    IndexRow++;
                    htmlTable.Append("<tr>");
                    if (Table.IsIndex)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append(IndexRow);
                        htmlTable.Append("</td>");
                    }
                    foreach (var col in Table.Columns)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append(col.Title);
                        htmlTable.Append("</td>");
                    }

                    if (Table.IsEdit)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-edit az-btn-edit\"></i>");
                        htmlTable.Append("</td>");
                    }
                    if (Table.IsDelete)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-trash-alt az-btn-delete\"></i>");
                        htmlTable.Append("</td>");
                    }
                    htmlTable.Append("</tr>");
                }
            }
            else {
                IList _dataList = (IList)Data;
                foreach (var item in _dataList)
                {

                    IndexRow++;

                    htmlTable.Append("<tr>");
                    if (Table.IsIndex)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append(IndexRow);
                        htmlTable.Append("</td>");
                    }
                    var d = item.GetType();
                    foreach (var col in Table.Columns)
                    {
                        htmlTable.Append("<td >");
                        if ( !string.IsNullOrEmpty(col.FieldName) && d.GetProperty(col.FieldName) != null) {
                            htmlTable.Append(d.GetProperty(col.FieldName).GetValue(item));
                        }                     
                        htmlTable.Append("</td>");
                    }

                    //<i class="fas fa-print"></i>
                    //<i class="fas fa-barcode"></i>
                    if (Table.IsEdit)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-edit az-btn-edit\"></i>");
                        htmlTable.Append("</td>");
                    }
                    if (Table.IsDelete)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-trash-alt az-btn-delete\"></i>");
                        htmlTable.Append("</td>");
                    }
                    htmlTable.Append("</tr>");

                }
            }
            htmlTable.Append("</tbody>");
        }
        private void RenderBottom(StringBuilder htmlTable, TableTag Table)
        {
        }
    }
}
