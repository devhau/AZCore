using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-date-model")]
    public class AZDateModel : AZDate, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-date")]
    public class AZDate : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" >", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0:dd/MM/yyyy}\"", InputValue), InputName);
            if (AddJs)
            {
                this.AddJS("$(function(){ $('." + this.TagId + "').singleDatePicker();});");
            }
        }
    }
  
}
