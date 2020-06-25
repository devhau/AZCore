using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-password-model")]
    public class AZPasswordModel : AZPassword
    {
    }

    [HtmlTargetElement("az-password")]
    public class AZPassword : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "password", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
        }
    }
}
