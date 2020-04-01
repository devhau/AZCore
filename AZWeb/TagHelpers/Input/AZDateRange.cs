using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Input
{
    [HtmlTargetElement("az-date-range-model")]
    public class AZDateRangeModel : AZDateRange, IAZModelInput
    {
        public IEntityModel Model { get; set; }
        public Expression<Func<IEntityModel, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-date-range")]
    public class AZDateRange : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label><br/>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" >", "text", InputClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);

            this.AddJS("$(function(){ $('." + this.TagId + "').daterangepicker(); });");
        }
    }
  
}
