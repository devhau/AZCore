using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-text-model")]
    public class AZTextModel : AZText, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-text")]
    public class AZText : AZInput
    {
        public bool IsOnlyCharacter { get; set; }
        public bool IsOnlyLetter { get; set; }
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (IsOnlyCharacter& !IsOnlyLetter)
                this.Attr += " onkeypress=\"return /[a-zA-Z0-9]/i.test(event.key)\" ";

            if (IsOnlyLetter)
                this.Attr += " onkeypress=\"return /[a-zA-Z]/i.test(event.key)\" ";
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue.HtmlEncode2()), InputName);
        }
    }
}
