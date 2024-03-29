﻿using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace AZWeb.Module.TagHelper.Input
{
    public class AZSelect<TService> : AZSelect        
    {
        public Expression<Func<object, bool>> WhereFunc { get; set; }
        public Expression<Func<Type>> FuncType { get; set; }
        protected override void InitData()
        {
            Type DataType;
            if (FuncType == null)
                DataType = typeof(TService);
            else
                DataType = FuncType.Compile().Invoke();
            base.InitData();
            if (DataType != null&& DataType!= this.GetType())
            {
                this.Data = DataType.GetListDataByDataType(this.ViewContext.HttpContext, NullText.IsNullOrEmpty()&& !this.InputLabel.IsNullOrEmpty()&&IsNullFirst ? "Chọn " + this.InputLabel.ToLower():"", WhereFunc);
            }
            if (this.InputValue != null  && DataType.IsEnum && !(this.InputValue is TService)) {
                this.InputValue=(TService)this.InputValue;
            }
            if (this.InputValue == null && this.Model == null)
            {
                this.InputValue = this.InputValueDefault;
            }
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
        public System.Collections.Generic.List<ItemValue> Data { get; set; }
        [HtmlAttributeName("null-text")]
        public string NullText { get; set; }
        public bool IsMultiple { get; set; }
        public bool IsNullFirst { get; set; } = true;
        protected override void InitData()
        {
            
            if(this.TagClass.IndexOf("select2") >0)
                this.TagClass += " select2 ";
            if (Data == null && ListObject != null&& ListObject is IList)
            {
                Data = new System.Collections.Generic.List<ItemValue>();
                foreach (var item in (IList)ListObject) {
                    Data.Add(item.GetItemValue());
                }
            }
            if (IsMultiple) {
                this.Attr += "  multiple='multiple' ";
            }
            base.InitData();
        }

        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (this.Data == null) this.Data = new System.Collections.Generic.List<ItemValue>();
            htmlBuild.AppendFormat("<select class=\"{0}\" name=\"{1}\" {2} {3} placeholder=\"{4}\" style=\"width: 100% \">", TagClass, InputName, string.IsNullOrEmpty(InputId) ? "" : string.Format("id=\"{0}\"", InputId), Attr, InputPlaceholder);
            if (!string.IsNullOrEmpty(NullText)& IsNullFirst) {
                this.Data.Insert(0, new ItemValue() { Value = null, Display = NullText, });
            }
            IList InputValues =null;
            if (this.InputValue !=null&& this.InputValue is IList) {
                InputValues = (IList)this.InputValue;
            }
            foreach (var item in this.Data)
            {
                string ItemActive = "";
                if (item.Value != null && item.Value.Equals(this.InputValue)) { ItemActive = " selected=\"selected\""; }
                if (item.Value != null && IsMultiple && InputValues != null && InputValues.IndexOf(item.Value) >= 0)
                { ItemActive = " selected=\"selected\""; }
                htmlBuild.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3} data-item='{4}' >{2}</option>", item.Value, item.Name, item.Display, ItemActive,item.Item.ToJson(true));
            }
            htmlBuild.Append("</select>");
            
            if(AddJs) this.AddJS("$('." + this.TagId + "').select2({theme: 'bootstrap4', width: 'resolve' });");
        }
    }
}
