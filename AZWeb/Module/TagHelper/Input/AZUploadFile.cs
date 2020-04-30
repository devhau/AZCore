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
        public bool ShowDrop { get; set; }
        public string ImgWith { get; set; }
        public string ImgHeight { get; set; }
        public string FileLabel { get; set; } = "Choose file";
        public bool IsMultiple { get; set; } = true;
        public bool IsImage { get; set; } = true;
        protected override void InitData()
        {
            base.InitData();
            this.TagClass = this.TagClass.Replace("form-control "," ");
                this.TagClass += " custom-file-input ";
            if (IsMultiple) {
                this.Attr += " multiple ";
            }
        }
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
            if (ImgWith != null && ImgHeight != null) 
                htmlBuild.AppendFormat("<div class=\"custom-file az-upload-file drop\" style=\"width:{0};height:{1};\">",this.ImgWith,this.ImgHeight);
            else
                htmlBuild.Append("<div class=\"custom-file az-upload-file drop\">");
            if (IsImage)
                htmlBuild.AppendFormat("<img {0} class=\"az-image\"/>", this.InputValue==null? "":( "src=\""+this.InputValue+"\""));
            htmlBuild.AppendFormat("<input type=\"{0}\" class=\"{1}\" id=\"{2}\" placeholder=\"{3}\" {4} {5} name=\"{6}\">", "file", TagClass, InputId, InputPlaceholder, Attr, InputValue.IsNullOrEmpty() ? "" : string.Format("value =\"{0}\"", InputValue), InputName);
            htmlBuild.AppendFormat("<label class=\"custom-file-label\" for=\"{0}\">{1}</label>", InputId, FileLabel);
            htmlBuild.Append("</div>");

            if (AddJs) this.AddJS($"$('.{TagId}').AZUploadFile();");
        }
    }
   
}
