using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-number-model")]
    public class AZNumberModel : AZNumber
    {
    }
  
    [HtmlTargetElement("az-number")]
    public class AZNumber : AZInput
    {
        public NumberType Type { get; set; } = NumberType.Integer;
        public int Digits { get; set; } = 2;
        public string GroupSeparator { get; set; } = ",";
        public bool AutoGroup { get; set; } = true;
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            //pattern=\"^\+?(?:[0-9]??).{5,14}[0-9]$\"
            if (Type == NumberType.OnlyNumber)
                this.Attr += " data-inputmask-regex=\"^[0-9]*$\"";
            else
                this.Attr += " data-inputmask=\"'alias': '" + Type.ToString().ToLower() + "'\" ";
            htmlBuild.AppendFormat("<input class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "number", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            if (Digits <= 0 || Type == NumberType.Integer)
            {
                Digits = 0;
            }
            if (AddJs)
            {
                if (Type == NumberType.OnlyNumber)
                    this.AddJS("$('." + TagId + "').inputmask({ rightAlign: false});");
                else
                    this.AddJS("$('." + TagId + "').inputmask({ rightAlign: false,groupSeparator:',' ,digits:'" + this.Digits + "',autoGroup: true });");
            }
        }
    }
    public enum NumberType
    {
        Integer,
        Decimal,
        Currency,
        OnlyNumber
    }
}
