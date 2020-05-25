using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;

namespace AZWeb.Module.TagHelper.Input
{
    public class AZLabel<TService> : AZLabel, IAZModelInput        
    {
        public Expression<Func<object, bool>> WhereFunc { get; set; }
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        public Expression<Func<Type>> FuncType { get; set; }
        protected override void InitData()
        {
            Type DataType;
            if (FuncType == null)
                DataType = typeof(TService);
            else
                DataType = FuncType.Compile().Invoke();
            this.BindModel();
            if (DataType != null&& DataType!= this.GetType())
            {
                this.Data = DataType.GetListDataByDataType(this.ViewContext.HttpContext, NullText.IsNullOrEmpty()&& !this.InputLabel.IsNullOrEmpty()&&IsNullFirst ? "Chọn " + this.InputLabel.ToLower():"", WhereFunc);
            }
            base.InitData();
            if (this.InputValue != null  && DataType.IsEnum && !(this.InputValue is TService)) {
                this.InputValue=(TService)this.InputValue;
            }
        }
    }
    [HtmlTargetElement("az-label-model")]
    public class AZLabelModel : AZLabel<AZLabelModel>
    {

    }
    [HtmlTargetElement("az-label")]
    public class AZLabel : AZInput
    {
        [HtmlAttributeName("list-object")]
        public object ListObject { get; set; }
        [HtmlAttributeName("data")]
        public System.Collections.Generic.List<ItemValue> Data { get; set; }
        [HtmlAttributeName("null-text")]
        public string NullText { get; set; }
        public bool IsNullFirst { get; set; } = true;
        public bool IsUseLable { get; set; } = true;
        protected override void InitData()
        {
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
            if (!string.IsNullOrEmpty(NullText) & IsNullFirst)
            {
                this.Data.Insert(0, new ItemValue() { Value = null, Display = NullText, });
            }
            IList InputValues =null;
            if (this.InputValue !=null&& this.InputValue is IList) {
                InputValues = (IList)this.InputValue;
            }

            var item = this.Data.FirstOrDefault(p=>p.Value.Equals(this.InputValue));

            if (IsUseLable) {
                htmlBuild.AppendFormat("<lable class=\"{0}\" name=\"{1}\" {2} {3} placeholder=\"{4}\"  data-item='{5}'>", TagClass, InputName, string.IsNullOrEmpty(InputId) ? "" : string.Format("id=\"{0}\"", InputId), Attr, 
                    InputPlaceholder, item.Item.ToJson(true));
            }
            if (item != null)
            {
                htmlBuild.Append(item.Display);
            }
            if (IsUseLable)
                htmlBuild.Append("</lable>");
            
        }
    }
}
