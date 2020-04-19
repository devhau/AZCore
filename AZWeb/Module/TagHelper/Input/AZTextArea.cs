using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-text-area-model")]
    public class AZTextAreaModel : AZTextArea, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-text-area")]
    public class AZTextArea : AZInput
    {
        public int Rows { get; set; } = 7;
        public int Cols { get; set; } = 20;
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (!string.IsNullOrEmpty(InputLabel))
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            htmlBuild.AppendFormat("<textarea  type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "text", TagClass, InputId, InputPlaceholder, Attr, string.Format("rows=\"{0}\" cols=\"{1}\"",this.Rows,this.Cols), InputName);
           
            if(!InputValue.IsNullOrEmpty()) {
                htmlBuild.Append(InputValue);
            }
            htmlBuild.Append("</textarea>");
            this.AddJS("$('." + this.TagId + "').summernote();");
        }
    }
}
