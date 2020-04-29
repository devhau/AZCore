using AZCore.Database;
using AZCore.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-upload-file-model")]
    public class AZUploadFileModel : AZUploadFile, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            base.InitData();
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-upload-file")]
    public class AZUploadFile : AZInput
    {
        public string FileLabel { get; set; } = "Choose file";
        protected override void InitData()
        {
            base.InitData();
            this.TagClass = this.TagClass.Replace("form-control "," ");
                this.TagClass += " custom-file-input ";
        }
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            htmlBuild.Append("<div class=\"input-group\"><div class=\"custom-file\">");
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "file", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            htmlBuild.AppendFormat("<label class=\"custom-file-label\" for=\"{0}\">{1}</label>", InputId, FileLabel);
            htmlBuild.Append("</div></div>");

            if (AddJs) this.AddJS($"$('.{TagId}').AZUploadFile();");
        }
    }
   
}
