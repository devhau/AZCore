using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Module;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    public class AZSelect<TModel> : AZSelect,IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        public Expression<Func<Type>> FuncType { get; set; }
        protected override void InitData()
        {
            Type DataType;
            if (FuncType == null)
                DataType = typeof(TModel);
            else
                DataType = FuncType.Compile().Invoke();
            this.BindModel();
            if (DataType != null&& DataType!= this.GetType())
            {
                this.Data = DataType.GetListDataByDataType(this.ViewContext.HttpContext, NullText.IsNullOrEmpty()&& !this.InputLabel.IsNullOrEmpty()? "Chọn " + this.InputLabel.ToLower():"");
            }
            base.InitData();
            if (this.InputValue != null  && DataType.IsEnum && !(this.InputValue is TModel)) {
                this.InputValue=(TModel)this.InputValue;
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
        public bool AddJs { get; set; } = true;
        protected override void InitData()
        {
            
            this.TagClass += " select2 ";
            if (Data == null && ListObject != null&& ListObject is IList)
            {
                Data = new System.Collections.Generic.List<ItemValue>();
                foreach (var item in (IList)ListObject) {
                    Data.Add(item.GetItemValue());
                }
            }
        }

        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (this.Data == null) this.Data = new System.Collections.Generic.List<ItemValue>();
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<select class=\"{0}\" name=\"{1}\" {2} {3} placeholder=\"{4}\" style=\"width: 100% \">", TagClass, InputName, string.IsNullOrEmpty(InputId) ? "" : string.Format("id=\"{0}\"", InputId), Attr, InputPlaceholder);
            if (!string.IsNullOrEmpty(NullText)) {
                this.Data.Insert(0, new ItemValue() { Value = null, Display = NullText, });
            }
            foreach (var item in this.Data)
            {
                string ItemActive = "";
                if (item.Value != null && item.Value.Equals(this.InputValue)) { ItemActive = " selected=\"selected\""; }
                htmlBuild.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3} data-item='{3}' >{2}</option>", item.Value, item.Name, item.Display, ItemActive,item.Item.ToJson());
            }
            htmlBuild.Append("</select>");
            if(AddJs) this.AddJS("$(function(){ $('." + this.TagId + "').select2({theme: 'bootstrap4', width: 'resolve' }); });");
        }
    }
}
