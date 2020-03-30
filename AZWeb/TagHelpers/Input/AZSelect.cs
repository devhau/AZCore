using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.TagHelpers.Input
{
    public class AZSelect<TModel> : AZSelect
    {
        public IEntityModel Model { get; set; }
        public Expression<Func<IEntityModel, object>> Func { get; set; }
        
        protected Type DataType { get; set; }
        public override void Init(TagHelperContext context)
        {
            this.DataType = typeof(TModel);
            base.Init(context);
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Func != null)
            {
                try
                {
                    var memberExpression = this.Func.Body as MemberExpression ?? ((UnaryExpression)this.Func.Body).Operand as MemberExpression;
                    this.InputName = memberExpression.Member.Name;
                    if (string.IsNullOrEmpty(this.InputId))
                        this.InputId = string.Format("Input{0}", this.InputName);
                    if (Model != null)
                    {
                        this.InputValue = this.Func.Compile()(Model);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            if (DataType != null) {
                this.Data = new System.Collections.Generic.List<AZItemValue>();
                if (DataType.IsEnum)
                {
                    foreach (var item in Enum.GetValues(DataType)) {
                        this.Data.Add(item.GetItemValueByEnum());
                    }       
                }
                else if (DataType.IsTypeFromInterface<IEntityService>()) {
                  var service=  this.ViewContext.HttpContext.RequestServices.GetService(DataType) as IEntityService;
                  var fnGetAll=  DataType.GetMethod("GetAll");
                    if(fnGetAll!=null){
                        var rsData= (IList)fnGetAll.Invoke(service,null);
                        foreach (var item in rsData)
                        {
                            this.Data.Add(item.GetItemValue()) ;
                        }
                    }


                }
            }
            base.Process(context, output);
        }
    }
    [HtmlTargetElement("az-select")]
    public class AZSelect: AZTagHelper
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = " form-control select2";
        [HtmlAttributeName("id")]
        public string InputId { get; set; }
        [HtmlAttributeName("name")]
        public string InputName { get; set; }
        [HtmlAttributeName("label")]
        public string InputLabel { get; set; }
        [HtmlAttributeName("placeholder")]
        public string InputPlaceholder { get; set; }
        [HtmlAttributeName("value")]
        public object InputValue { get; set; }
        [HtmlAttributeName("data")]
        public System.Collections.Generic.List<AZItemValue> Data { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            this.InputClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            if(!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<select class=\"{0}\" name=\"{1}\" {2} {3}>", InputClass, InputName,string.IsNullOrEmpty(InputId)?"":string.Format("id=\"{0}\"", InputId), Attr);
            foreach (var item in this.Data) {
                string ItemActive = "";
                if (item.ItemValue!=null&&item.ItemValue.Equals(this.InputValue)) { ItemActive = " selected=\"selected\""; }
                htmlBuild.AppendFormat("<option value=\"{0}\" name=\"{1}\" {3} >{2}</option>", item.ItemValue, item.ItemName, item.ItemDisplay, ItemActive);
            }
                
            htmlBuild.Append("</select>");
            output.Content.SetHtmlContent(htmlBuild.ToString());
            this.AddJS("$(function(){ $('." + this.TagId + "').select2({theme: 'bootstrap4'}); });");
        }
    }

  
}
