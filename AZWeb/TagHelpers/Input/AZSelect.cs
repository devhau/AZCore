using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common;
using AZWeb.TagHelpers;
using AZWeb.TagHelpers.Input;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.TagHelpers.Input
{
    public class AZSelect<TModel> : AZSelect,IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            var DataType = typeof(TModel);
            this.BindModel();
            if (DataType != null)
            {
                this.Data = DataType.GetListDataByDataType(this.ViewContext.HttpContext, "Chọn " + this.InputLabel);
            }
            base.InitData();
        }
       
            
    }
    [HtmlTargetElement("az-select")]
    public class AZSelect: AZInput
    {
        [HtmlAttributeName("data")]
        public System.Collections.Generic.List<AZItemValue> Data { get; set; }
        [HtmlAttributeName("null-text")]
        public string NullText { get; set; } 
        protected override void InitData()
        {
            this.InputClass = "form-control select2";
        }

        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<select class=\"{0}\" name=\"{1}\" {2} {3} placeholder=\"{4}\" style=\"width: 100% \">", InputClass, InputName, string.IsNullOrEmpty(InputId) ? "" : string.Format("id=\"{0}\"", InputId), Attr, InputPlaceholder);
            if (!string.IsNullOrEmpty(NullText)) {
                this.Data.Insert(0, new AZItemValue() { ItemValue = null, ItemDisplay = NullText, });
            }
            foreach (var item in this.Data)
            {
                string ItemActive = "";
                if (item.ItemValue != null && item.ItemValue.Equals(this.InputValue)) { ItemActive = " selected=\"selected\""; }
                htmlBuild.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3} >{2}</option>", item.ItemValue, item.ItemName, item.ItemDisplay, ItemActive);
            }

            htmlBuild.Append("</select>");
            this.AddJS("$(function(){ $('." + this.TagId + "').select2({theme: 'bootstrap4', width: 'resolve' }); });");
        }
    }
}
