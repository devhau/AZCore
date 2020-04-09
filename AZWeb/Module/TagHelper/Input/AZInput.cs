using AZCore.Database;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Input
{
    public interface IAZModelInput 
    {
        IEntity Model { get; set; }
        Expression<Func<IEntity, object>> Func { get; set; }
        string InputName { get; set; }
        string InputId { get; set; }
        object InputValue { get; set; }
    }
    public abstract class AZInput: TagHelperBase
    {
        [HtmlAttributeName("attr")]
        public string Attr { get; set; }
        [HtmlAttributeName("class")]
        public string InputClass { get; set; } = "form-control";
        [HtmlAttributeName("id")]
        public string InputId { get; set; }
        [HtmlAttributeName("name")]
        public string InputName { get; set; }
        [HtmlAttributeName("label")]
        public string InputLabel { get; set; }
        [HtmlAttributeName("placeholder")]
        public string InputPlaceholder { get; set; }
        [HtmlAttributeName("value")]
        public object InputValue { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            InitData();
            this.InputClass += " " + this.TagId;
            output.TagName = "";
            StringBuilder htmlBuild = new StringBuilder();
            RenderHtml(htmlBuild);
            output.Content.SetHtmlContent(htmlBuild.ToString());
            await Task.CompletedTask;
        }
       
        protected virtual void InitData() { }
        protected abstract void RenderHtml(StringBuilder htmlBuild);
    }
    public static class AZModelInputEx {
        public static void BindModel(this IAZModelInput input) {
            if (input.Func != null)
            {
                var memberExpression =  input.Func.Body as MemberExpression ?? ((UnaryExpression)input.Func.Body).Operand as MemberExpression;
                input.InputName = memberExpression.Member.Name;
                if (string.IsNullOrEmpty(input.InputId))
                    input.InputId = string.Format("Input{0}", input.InputName);
                if (input.Model != null)
                {
                    input.InputValue = input.Func.Compile()(input.Model);
                }
            }
        }
    }
}
