using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-date-range-model")]
    public class AZDateRangeModel : AZDateRange
    {
    }

    [HtmlTargetElement("az-date-range")]
    public class AZDateRange : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\" >", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            if (AddJs)
            {
                this.AddJS("$('." + this.TagId + "').daterangepicker();");
            }
        
        }
    }
}
