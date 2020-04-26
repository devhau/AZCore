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
        [HtmlAttributeName("value-default")]
        public object InputValueDefault { get; set; }
        [HtmlAttributeName("cmd-key")]
        public string CMD { get; set; }
        [HtmlAttributeName("max-length")]
        public int MaxLength { get; set; }
        public bool AddJs { get; set; } = true;
        public Func<string, string> ScriptInput { get; set; }
        public string AddonBefore { get; set; }
        public string AddonAfter { get; set; }
        protected bool? LabelAfter = false;
        public override void Init(TagHelperContext context)
        {
            if (string.IsNullOrEmpty(TagClass))
            {
                TagClass += " form-control";
            }
            base.Init(context);
        }
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            InitData();
            if (!string.IsNullOrEmpty(CMD))
            {
                this.Attr += $"  data-cmd-key='{CMD}' ";
            }
            if (LabelAfter==false && !string.IsNullOrEmpty(InputLabel)) {
                htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            }
            if (MaxLength > 0) {
                this.Attr += $" maxlength='{MaxLength}' ";
            }
            if (!string.IsNullOrEmpty(AddonBefore) || !string.IsNullOrEmpty(AddonAfter)) {
                htmlBuild.Append("<div class=\"input-group\">");
            }
            if (!string.IsNullOrEmpty(AddonBefore)) {
                htmlBuild.AppendFormat("<div class=\"input-group-prepend\"><span class=\"input-group-text\">{0}</span></div>", AddonBefore);
            }
            RenderHtml(htmlBuild);
            if (!string.IsNullOrEmpty(AddonAfter))
            {
                htmlBuild.AppendFormat("<div class=\"input-group-append\"><span class=\"input-group-text\">{0}</span></div>", AddonAfter);
            }
            if (!string.IsNullOrEmpty(AddonBefore) || !string.IsNullOrEmpty(AddonAfter))
            {
                htmlBuild.Append("</div>");
            }
            if (LabelAfter == true && !string.IsNullOrEmpty(InputLabel))
            {
                    htmlBuild.AppendFormat("<label for=\"{1}\">{0}</label>", InputLabel, InputId);
            }
            if (ScriptInput != null) {
                this.AddJS(ScriptInput(TagId));
            }
            return Task.CompletedTask;
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
