using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-table")]
    public class AZTable : TagHelperBase
    {
        [HtmlAttributeName("FunKey")]
        public Func<dynamic, object> FunKey { get; set; }
        [HtmlAttributeName("fun-where-edit")]
        public Func<dynamic, bool> FunEdit { get; set; }
        [HtmlAttributeName("fun-where-remove")]
        public Func<dynamic, bool> FunRemove { get; set; }
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

        static Regex regex = new Regex(@"{[a-zA-Z][a-zA-Z0-1]+\}");
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<table class=\"table table-bordered table-hover az-table {0}\" role=\"grid\">", this.TagClass);
            this.RenderHeader(htmlBuild);
            this.RenderBody(htmlBuild, Data);
            this.RenderBottom(htmlBuild);
            htmlBuild.Append("</table>");
            return Task.CompletedTask;
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
                    if (!string.IsNullOrEmpty(item.Permisson)&&!this.HasPermission(item.Permisson))
                        continue;
                    if (item.DataType != null && !this.DataDic.ContainsKey(item.DataType))
                    {
                        this.DataDic[item.DataType] = item.DataType.GetListDataByDataType(this.ViewContext.HttpContext, " ", item.WhereFunc);
                    }
                    htmlTable.AppendFormat("<th {0} name='{1}'>", item.Width==0?"":string.Format("width='{0}px'", item.Width), item.FieldName);
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
                            if (!string.IsNullOrEmpty(col.Permisson) && !this.HasPermission(col.Permisson))
                                continue;
                            string TextDisplay = "";
                            if (!string.IsNullOrEmpty(col.FieldName) && d.GetProperty(col.FieldName) != null)
                            {
                                var itemValue = d.GetProperty(col.FieldName).GetValue(item);                              
                               
                                object ItemDisplay = itemValue;
                                if (col.DataType != null)
                                {
                                    var itemDic = this.DataDic[col.DataType].FirstOrDefault(p => p.Value!=null&&p.Value.Equals(itemValue));
                                    if (itemDic != null)
                                    {
                                        ItemDisplay = itemDic.Display;                                           
                                    }                                       
                                }
                                if (d.GetProperty(col.FieldName).PropertyType == typeof(bool) && !string.IsNullOrEmpty(col.TextTrue))
                                {
                                    TextDisplay = (bool)itemValue == true ? col.TextTrue : col.TextFalse;
                                }
                                else 
                                {
                                    TextDisplay = string.IsNullOrEmpty(col.FormatString) ? string.Format("{0}", ItemDisplay).HtmlEncode() : string.Format(col.FormatString, (ItemDisplay?.GetType()==typeof(string)?ItemDisplay?.ToString().HtmlEncode():ItemDisplay));
                                    foreach (Match match in regex.Matches(TextDisplay))
                                    {
                                        foreach (Group m in match.Groups)
                                        {
                                            var pro = m.Value.TrimStart('{').TrimEnd('}');
                                            if (d.GetProperty(pro) != null)
                                            {
                                                TextDisplay = TextDisplay.Replace(m.Value, string.Format("{0}", d.GetProperty(pro).GetValue(item)).HtmlEncode());
                                            }
                                        }
                                    }
                                }

                                htmlTable.AppendFormat("<td data-value='{1}' data-name='{0}' class='{2}'>", col.FieldName, HttpUtility.UrlEncode(itemValue?.ToString()), col.ClassColumn);
                            }
                            else {
                                htmlTable.AppendFormat("<td  class='{0}'>", col.ClassColumn);
                                TextDisplay = col.Text;
                            }
                            if (!string.IsNullOrEmpty(col.LinkFormat)) {
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
                        if(FunEdit==null|| FunEdit(item))
                            htmlTable.Append("<i class=\"far fa-edit az-btn-edit\"></i>");
                        htmlTable.Append("</td>");
                    }
                    if (this.IsDelete)
                    {
                        htmlTable.Append("<td>");
                        if (FunRemove == null || FunRemove(item))
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
