using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            if (this.DefaultNow&& Model!=null) {
                this.DefaultNow = false;
            }
        }
    }

    [HtmlTargetElement("az-date")]
    public class AZDate : AZInput
    {
        public bool DefaultNow { get; set; } = false;
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label><br/>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" >", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0:dd/MM/yyyy}\"", InputValue), InputName);

            this.AddJS("$(function(){ $('." + this.TagId + "').singleDatePicker();});");
        }
    }
  
}
