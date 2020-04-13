using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-table")]
    public class AZTable : TagHelperBase
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
        [HtmlAttributeName("pagination")]
        public IPagination Pagination { get; set; }
        private Dictionary<Type, List<ItemValue>> DataDic { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.AppendFormat("<table class=\"table table-bordered table-hover {0}\" role=\"grid\">",this.TagClass);
            this.RenderHeader(htmlTable);
            this.RenderBody(htmlTable,Data);
            this.RenderBottom(htmlTable);
            htmlTable.Append("</table>");
            output.Content.SetHtmlContent(htmlTable.ToString());
        }
        private void RenderHeader(StringBuilder htmlTable)
        {
            this.DataDic = new Dictionary<Type, List<ItemValue>>();
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
                    htmlTable.AppendFormat("<th {0} >", item.Width==0?"":string.Format("width='{0}px'", item.Width));
                    htmlTable.Append(item.Title);
                    htmlTable.Append("</th>");
                    if (item.DataType != null&& !this.DataDic.ContainsKey(item.DataType)) {
                        this.DataDic[item.DataType] = item.DataType.GetListDataByDataType(this.ViewContext.HttpContext," ");
                    }
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
            if (Data == null) return;
            int IndexRow = (Pagination.PageIndex - 1) * Pagination.PageSize;

            if (IndexRow < 0) IndexRow = 0;
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
                            htmlTable.AppendFormat("<td  width='{0}px'>", col.Width);
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
                            string TextDisplay = "";
                            if (!string.IsNullOrEmpty(col.FieldName) && d.GetProperty(col.FieldName) != null)
                            {
                                var itemValue = d.GetProperty(col.FieldName).GetValue(item);                               
                                htmlTable.AppendFormat("<td data-value='{1}' data-name='{0}' class='{2}'>", col.FieldName,itemValue,col.ClassColumn);
                               
                                object ItemDisplay = itemValue;
                                if (col.DataType != null)
                                {
                                    var itemDic = this.DataDic[col.DataType].FirstOrDefault(p => p.Value!=null&&p.Value.Equals(itemValue));
                                    if (itemDic != null)
                                    {
                                        ItemDisplay = itemDic.Display;                                           
                                    }                                       
                                }
                                TextDisplay = string.IsNullOrEmpty(col.FormatString)?string.Format("{0}", ItemDisplay) : string.Format(col.FormatString, ItemDisplay);
                            }
                            else {
                                htmlTable.AppendFormat("<td  class='{0}'>", col.ClassColumn);
                                TextDisplay = col.Text;
                            }
                            if (!string.IsNullOrEmpty(col.LinkFormat)) {
                                Regex regex = new Regex(@"{[a-zA-Z][a-zA-Z0-1]+\}");
                                var link = col.LinkFormat;
                                foreach (Match match in regex.Matches(link))
                                {
                                    foreach (Group m in match.Groups)
                                    {
                                        var pro = m.Value.TrimStart('{').TrimEnd('}');
                                        if (d.GetProperty(pro) != null)
                                        {
                                            link = link.Replace(m.Value, string.Format("{0}", d.GetProperty(pro).GetValue(item)));
                                        }
                                    }
                                }
                                string classLink = "az-link";
                                string attLink = "";
                                if (col.Popup != PopupSize.None) 
                                {
                                    classLink = "az-link-popup";
                                    if (col.Popup == PopupSize.Small) {
                                        attLink = "modal-size='az-modal-sm'";
                                    }
                                    if (col.Popup == PopupSize.Large)
                                    {
                                        attLink = "modal-size='az-modal-lg'";
                                    }
                                    if (col.Popup == PopupSize.Extralarge)
                                    {
                                        attLink = "modal-size='az-modal-xl'";
                                    }
                                    if (col.Popup == PopupSize.Popup)
                                    {
                                        attLink = "modal-size='az-modal-none'";
                                    }
                                    if (col.Popup == PopupSize.FullScreen)
                                    {
                                        attLink = "modal-size='az-modal-full'";
                                    }
                                    if (col.ReLoadAfterPopupClose) {
                                        attLink += " reload='true' ";
                                    }
                                }
                                htmlTable.AppendFormat("<a href='{0}' class='{1}' {2} >", link, classLink, attLink);
                            }
                            if (col.Display == DisplayColumn.Icon || col.Display == DisplayColumn.IconText) {
                                htmlTable.AppendFormat(" <i class='{0}'/> ", col.Icon);
                            }
                            if (col.Display == DisplayColumn.Text || col.Display == DisplayColumn.TextIcon || col.Display == DisplayColumn.IconText)
                            {
                                htmlTable.AppendFormat("<span>{0}</span>", TextDisplay);
                            }
                            if (col.Display == DisplayColumn.TextIcon)
                            {
                                htmlTable.AppendFormat(" <i class='{0}'/> ", col.Icon);
                            }
                            if (!string.IsNullOrEmpty(col.LinkFormat))
                            {
                                htmlTable.AppendFormat("</a>");
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
