using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-number-model")]
    public class AZNumberModel : AZNumber, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
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
            //phonebe
            if (Type == NumberType.PhoneNumber)
            {
                Digits = 0;
                GroupSeparator = "";
                AutoGroup = false;
                this.Attr += " data-inputmask=\"'alias': 'phonebe'\" ";
            }
            else
            {
                this.Attr += " data-inputmask=\"'alias': '" + Type.ToString().ToLower() + "'\" ";
            }
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<input class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "number", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            if (Digits <= 0 || Type == NumberType.Integer) {
                Digits = 0;
            }
            
            this.AddJS($"$('.{TagId}').inputmask({{ rightAlign: false,groupSeparator:'{GroupSeparator}' ,digits:'{Digits}',autoGroup: {AutoGroup.ToString().ToLower()} }});");
        }
    }
    public enum NumberType
    {
        Integer,
        Decimal,
        Currency,
        PhoneNumber

    }
}
