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
    [HtmlTargetElement("az-code-model")]
    public class AZCodeModel : AZCode, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }

        protected override void InitData()
        {
            this.BindModel();
            if (this.Model != null)
            {
                this.Attr += " disabled ";
            }
            base.InitData();
        }
    }

    [HtmlTargetElement("az-code")]
    public class AZCode : AZInput
    {
        protected override void InitData()
        {

            if (InputValue == null) {
                InputValue = Guid.NewGuid().ToString();
            }
            this.Attr += " readonly ";
        }
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "text", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
        }
    }
   
}
