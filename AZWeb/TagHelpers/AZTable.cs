using AZWeb.Common;
using AZWeb.Common.Module.Attr;
using AZWeb.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZWeb.TagHelpers
{
    [HtmlTargetElement("az-table")]
    public class AZTable : AZTagHelper
    {
        [HtmlAttributeName("FunKey")]
        public Func<object, object> FunKey { get; set; }
        [HtmlAttributeName("is-index")]
        public bool IsIndex { get; set; } = true;
        [HtmlAttributeName("is-edit")]
        public bool IsEdit { get; set; } = true;
        [HtmlAttributeName("is-delete")]
        public bool IsDelete { get; set; } = true;
        [HtmlAttributeName("columns")]
        public List<TableColumnAttribute> Columns { get; set; }
        [HtmlAttributeName("data")]
        public object Data { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table class=\"table table-bordered table-hover dataTable\" role=\"grid\">");
            this.RenderHeader(htmlTable);
            this.RenderBody(htmlTable,Data);
            this.RenderBottom(htmlTable);
            htmlTable.Append("</table>");
            output.Content.SetHtmlContent(htmlTable.ToString());
        }
        private void RenderHeader(StringBuilder htmlTable)
        {
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr>");
            if (this.IsIndex) {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("#");
                htmlTable.Append("</th>");
            }
            if (this.Columns!=null) {
                foreach (var item in this.Columns)
                {
                    htmlTable.Append("<th class=\"sorting_asc\" tabindex=\"0\" rowspan =\"1\" colspan =\"1\" aria-sort=\"ascending\" width=\"" + item.Width + "\">");
                    htmlTable.Append(item.Title);
                    htmlTable.Append("</th>");
                }
            }

            if (this.IsEdit)
            {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("Sửa");
                htmlTable.Append("</th>");
            }
            if (this.IsDelete)
            {
                htmlTable.Append("<th width=\"50px\">");
                htmlTable.Append("Xóa");
                htmlTable.Append("</th>");
            }
            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
        }
        private void RenderBody(StringBuilder htmlTable,object Data)
        {
            int IndexRow = 0;
            
            htmlTable.Append("<tbody>");
            if (Data is DataTable)
            {
                var _dataTable = (DataTable)Data;
                foreach (var item in _dataTable.Rows)
                {
                    IndexRow++;
                    object itemId = null;
                    if (this.FunKey != null) itemId = FunKey(item);
                    htmlTable.AppendFormat("<tr data-item-id=\"{0}\">", itemId);
                    if (this.IsIndex)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append(IndexRow);
                        htmlTable.Append("</td>");
                    }
                    if (this.Columns != null)
                    {
                        foreach (var col in this.Columns)
                        {
                            htmlTable.Append("<td>");
                            htmlTable.Append(col.Title);
                            htmlTable.Append("</td>");
                        }
                    }
                    if (this.IsEdit)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-edit az-btn-edit\"></i>");
                        htmlTable.Append("</td>");
                    }
                    if (this.IsDelete)
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
                    object itemId = null;
                    if (this.FunKey != null) itemId = FunKey(item);
                    htmlTable.AppendFormat("<tr data-item-id=\"{0}\">", itemId);
                    if (this.IsIndex)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append(IndexRow);
                        htmlTable.Append("</td>");
                    }
                     if (this.Columns != null)
                    {
                        var d = item.GetType();
                        foreach (var col in this.Columns)
                        {
                            htmlTable.Append("<td >");
                            if (!string.IsNullOrEmpty(col.FieldName) && d.GetProperty(col.FieldName) != null) {
                                htmlTable.Append(d.GetProperty(col.FieldName).GetValue(item));
                            }
                            htmlTable.Append("</td>");
                        }
                    }
                    //<i class="fas fa-print"></i>
                    //<i class="fas fa-barcode"></i>
                    if (this.IsEdit)
                    {
                        htmlTable.Append("<td>");
                        htmlTable.Append("<i class=\"far fa-edit az-btn-edit\"></i>");
                        htmlTable.Append("</td>");
                    }
                    if (this.IsDelete)
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
        private void RenderBottom(StringBuilder htmlTable)
        {
        }
    }
}
