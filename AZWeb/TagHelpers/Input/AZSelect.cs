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
            if (DataType != null&& DataType!= this.GetType())
            {
                this.Data = DataType.GetListDataByDataType(this.ViewContext.HttpContext, NullText.IsNullOrEmpty()? "Chọn " + this.InputLabel.ToLower():"");
            }
            base.InitData();
        }
    }
    [HtmlTargetElement("az-select-model")]
    public class AZSelectModel : AZSelect<AZSelectModel>
    {

    }
    [HtmlTargetElement("az-select")]
    public class AZSelect: AZInput
    {
        [HtmlAttributeName("list-object")]
        public object ListObject { get; set; }
        [HtmlAttributeName("data")]
        public System.Collections.Generic.List<AZItemValue> Data { get; set; }
        [HtmlAttributeName("null-text")]
        public string NullText { get; set; } 
        protected override void InitData()
        {
            
            this.InputClass += " select2 ";
            if (Data == null && ListObject != null&& ListObject is IList)
            {
                Data = new System.Collections.Generic.List<AZItemValue>();
                foreach (var item in (IList)ListObject) {
                    Data.Add(item.GetItemValue());
                }
            }
        }

        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (this.Data == null) this.Data = new System.Collections.Generic.List<AZItemValue>();
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
