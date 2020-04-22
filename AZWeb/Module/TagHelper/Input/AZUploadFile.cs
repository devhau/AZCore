using AZCore.Database;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;

namespace AZWeb.Module.TagHelper.Input
{
    [HtmlTargetElement("az-text-model")]
    public class AZUploadFileModel : AZUploadFile, IAZModelInput
    {
        public IEntity Model { get; set; }
        public Expression<Func<IEntity, object>> Func { get; set; }
        protected override void InitData()
        {
            this.BindModel();
        }
    }

    [HtmlTargetElement("az-text")]
    public class AZUploadFile : AZInput
    {
        protected override void RenderHtml(StringBuilder htmlBuild)
        {
        } 
    }
   
}
