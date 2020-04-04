using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers.Input
{
    [HtmlTargetElement("az-checkbox-model")]
    public class AZCheckboxModel : AZCheckbox, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
            if (true.Equals(this.InputValue))
            {
                this.Attr += " checked";
            }
            else
            {
                this.InputValue = true;
            }
        }
    }

    [HtmlTargetElement("az-checkbox")]
    public class AZCheckbox : AZInput
    {
       
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.Append("<div class=\"icheck-primary d-inline\">");
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "checkbox", InputClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.Append("</div>");
        }
    }
}
