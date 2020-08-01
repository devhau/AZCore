using AZCore.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AZWeb.Module.Html
{
    public enum InputType {
        Button,
        Checkbox,
        Color,
        Date,
        Datetime,
        Email,
        File,
        Hidden,
        Image,
        Month,
        Number,
        Password,
        Radio,
        Range,
        Reset,
        Search,
        Submit,
        Tel,
        Text,
        Time,
        Url,
        Week,
    }
    
    public class ZHtml
    {
        private readonly IHtmlHelper html;

        private IHtmlHelper GetHtml()
        {
            return html;
        }

        public ZHtml(IHtmlHelper _html) { html = _html; }
        public IDictionary<string, object> AnonymousObjectToHtmlAttributes(object htmlAttributes)
        {
            return (htmlAttributes == null ? new Dictionary<string, object>() : HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        public IHtmlContent Input(InputType type, object value, object htmlAttributes) {
            var tagBuilder = new TagBuilder("Input");
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            dicAttribute["value"] = value;
            tagBuilder.MergeAttributes(dicAttribute);            
            tagBuilder.AddCssClass("form-control");
            tagBuilder.Attributes["type"] = type.ToString().ToLower();
            return tagBuilder;
        }
    }
    public class ZHtml<TModel> : ZHtml
    {
        private readonly IHtmlHelper<TModel> html;

        private IHtmlHelper<TModel> GetHtml()
        {
            return html;
        }
        private bool isModelNull { get; }

        public ZHtml(IHtmlHelper<TModel> _html) : base(_html) { html = _html; isModelNull = html.ViewData.Model == null; }
        public IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes = null)
        {
            return LabelFor(expression, null, htmlAttributes);
        }
        public IHtmlContent LabelFor<TResult>(Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes = null)
        {

            string resolvedLabelText = labelText ?? expression.GetName();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return HtmlString.Empty;
            }
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            var tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes["for"] = expression.GetName();
            tagBuilder.InnerHtml.AppendHtml(resolvedLabelText);
            return tagBuilder;
        }
        public IHtmlContent InputFor<TResult>(InputType type, Expression<Func<TModel, TResult>> expression, object htmlAttributes = null)
        {
            var tagBuilder = new TagBuilder("Input");
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            if(!isModelNull)
                dicAttribute["value"] = expression.Compile()(GetHtml().ViewData.Model);
            if (!dicAttribute.ContainsKey("id"))
            {
                dicAttribute["id"] = expression.GetName();
            }
            if (!dicAttribute.ContainsKey("name"))
            {
                dicAttribute["name"] = expression.GetName();
            }
            tagBuilder.MergeAttributes(dicAttribute);
            tagBuilder.AddCssClass("form-control");
            tagBuilder.Attributes["type"] = type.ToString().ToLower();
            return tagBuilder;
        }
        public IHtmlContent TextboxFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Text, expression, htmlAttributes);
        }
        public IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Hidden, expression, htmlAttributes);
        }
        public IHtmlContent DateTimeFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Datetime, expression, htmlAttributes);
        }
        public IHtmlContent DateFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Date, expression, htmlAttributes);
        }
        public IHtmlContent PasswordFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes = null)
        {
            return InputFor(InputType.Password, expression, htmlAttributes);
        }
        public IHtmlContent TextAreaFor<TResult>(Expression<Func<TModel, TResult>> expression, int rows=5, int columns=10, object htmlAttributes = null) {
            var tagBuilder = new TagBuilder("TextArea");
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!dicAttribute.ContainsKey("id"))
            {
                dicAttribute["id"] = expression.GetName();
            }
            if (!dicAttribute.ContainsKey("name"))
            {
                dicAttribute["name"] = expression.GetName();
            }
            dicAttribute["rows"] = rows;
            dicAttribute["columns"] = columns;
            tagBuilder.InnerHtml.AppendHtml("{0}".Frmat(expression.Compile()(GetHtml().ViewData.Model)));
            tagBuilder.MergeAttributes(dicAttribute);
            tagBuilder.AddCssClass("form-control");
            return tagBuilder;
        }
        IHtmlContent ListItemToOption(SelectListItem item)
        {
            TagBuilder builder = new TagBuilder("option");

            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            builder.InnerHtml.AppendHtml(item.Text);
            return builder;
        }
        public IHtmlContent DropDownListFor<TResult>( Expression<Func<TModel, TResult>> expression, string optionLabel=null, object htmlAttributes=null)
        {
            return DropDownListFor(expression,optionLabel,null, htmlAttributes);
        }
        public IHtmlContent DropDownListFor<TResult>(Expression<Func<TModel, TResult>> expression, string optionLabel, IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
        {
            var type = expression.Body is MemberExpression member ? member.Type : null;
            if (type != null && type.IsEnum && selectList == null)
            {
                selectList = Enum.GetValues(type).Cast<object>().Select(p => new SelectListItem()
                {
                    Value = p.ToString(),
                    Text = p.GetItemValueByEnum().Display
                });
            }
            var tagBuilder = new TagBuilder("select");
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!dicAttribute.ContainsKey("id"))
            {
                dicAttribute["id"] = expression.GetName();
            }
            if (!dicAttribute.ContainsKey("name"))
            {
                dicAttribute["name"] = expression.GetName();
            }
            var val = string.Empty;
            if (!isModelNull)
                val = "{0}".Frmat(expression.Compile()(GetHtml().ViewData.Model));
            if (optionLabel != null)
            {
                var optionDefault = new SelectListItem();
                optionDefault.Text = optionLabel;
                tagBuilder.InnerHtml.AppendHtml(ListItemToOption(optionDefault));
            }
            foreach (var item in selectList)
            {
                if (!isModelNull&&item.Value == val & !item.Selected) item.Selected = true;
                tagBuilder.InnerHtml.AppendHtml(ListItemToOption(item));
            }

            tagBuilder.MergeAttributes(dicAttribute);
            tagBuilder.AddCssClass("form-control");
            return tagBuilder;
        }
    }
}
