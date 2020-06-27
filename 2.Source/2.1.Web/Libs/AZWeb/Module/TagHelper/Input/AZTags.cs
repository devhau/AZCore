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
    [HtmlTargetElement("az-tags-model")]
    public class AZTagsModel : AZTags
    {
    }

    [HtmlTargetElement("az-tags")]
    public class AZTags : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            this.AddJS("$('." + this.TagId + "').tagsinput();");
        }
    }
   
}
