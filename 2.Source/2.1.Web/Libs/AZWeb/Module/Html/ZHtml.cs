using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Constant;
using AZWeb.Module.TagHelper.Theme;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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
    public static class ZHtmlExtension
    {
        public static TagBuilder AddJS(this ZHtml html,TagBuilder tag,Func<string,string> funcJS)
        {
            if (tag.Attributes["id"] != null)
            {
                html.AddJS(funcJS("#{0}".Frmat(tag.Attributes["id"])));
            }
            else if (tag.Attributes["class"] != null && tag.Attributes["class"].Contains("az_id_")) { html.AddJS(funcJS(".{0}".Frmat(tag.Attributes["class"].Split(' ').First(p => p.Contains("az_id_"))))); }
            else {
                html.AddJS(funcJS("[name='{0}']".Frmat(tag.Attributes["name"])));
            }
            return tag;
        }
    }
    public class ZHtml
    {
        string _urlCurrent;
        public string UrlCurrent => _urlCurrent ?? (_urlCurrent = HttpContext.Items[AZWebConstant.KeyUrlCurrent] as string);
        protected HtmlContent HtmlSite { get => HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
        private readonly IHtmlHelper html;
        protected HttpContext HttpContext { get; }
        public void AddJS(string Code, string link = "", string CDN = "")
        {
            this.HtmlSite.AddJS(Code, link, CDN, this.HttpContext.Items[AZHtml.scriptContent] == null ? 1 : this.HttpContext.Items[AZHtml.scriptContent].To<int>());
        }
        public void AddCSS(string Code, string link = "", string CDN = "")
        {
            this.HtmlSite.AddCSS(Code, link, CDN, this.HttpContext.Items[AZHtml.scriptContent] == null ? 1 : this.HttpContext.Items[AZHtml.scriptContent].To<int>());
        }
        private IHtmlHelper GetHtml()
        {
            return html;
        }

        public ZHtml(IHtmlHelper _html) { html = _html; HttpContext = _html.ViewContext.HttpContext; }
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
            var fileInfo = expression.GetAttribute<FieldAttribute>();

            string resolvedLabelText = labelText ?? fileInfo.Display?? expression.GetName();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return HtmlString.Empty;
            }
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            var tagBuilder = new TagBuilder("label");
            tagBuilder.Attributes["for"] = expression.GetName();
            tagBuilder.InnerHtml.AppendHtml(resolvedLabelText);
            tagBuilder.MergeAttributes(dicAttribute);
            return tagBuilder;
        }
        public TagBuilder InputFor<TResult>(InputType type, Expression<Func<TModel, TResult>> expression, object htmlAttributes = null)
        {
            var tagBuilder = new TagBuilder("Input");
            IDictionary<string, object> dicAttribute = AnonymousObjectToHtmlAttributes(htmlAttributes);
            if(!isModelNull)
                dicAttribute["value"] = expression.Compile()(GetHtml().ViewData.Model);
            if (type == InputType.Checkbox) {
                if (true.Equals(dicAttribute["value"]))
                {
                    dicAttribute["checked"] = true;
                }
                dicAttribute["value"] = 1;
            }
           
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
        public IHtmlContent TextBoxFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Text, expression, htmlAttributes);
        }
        public IHtmlContent HiddenFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return InputFor(InputType.Hidden, expression, htmlAttributes);
        }
        public IHtmlContent DateTimeFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return this.AddJS(InputFor(InputType.Datetime, expression, htmlAttributes), id => "$('{0}').daterangepicker();".Frmat(id));
        }
        public IHtmlContent DateFor<TResult>(Expression<Func<TModel, TResult>> expression,object htmlAttributes = null)
        {
            return this.AddJS(InputFor(InputType.Date, expression, htmlAttributes),id=> "$('{0}').singleDatePicker();".Frmat(id));
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
            if (!isModelNull)
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
        public IHtmlContent CheckBoxFor<TResult>(Expression<Func<TModel, TResult>> expression, object htmlAttributes = null) {
            return InputFor(InputType.Checkbox, expression, htmlAttributes);
        }
        public IHtmlContent DropDownListFor<TService, TModel2, TResult>(Expression<Func<TModel, TResult>> expression, Expression<Func<TModel2, bool>> funcWhere, string optionLabel = null, object htmlAttributes = null)
            where TService : EntityService<TModel2>
            where TModel2 : IEntity
        {
            IEnumerable<SelectListItem> selectList = null;
            var sv = this.html.ViewContext.HttpContext.GetService<TService>();
            if (sv != null)
            {
                if (funcWhere != null)
                {
                    selectList = sv.Select(funcWhere).Select(p => { var item = p.GetItemValue(); return new SelectListItem() { Text = item.Display, Value = "{0}".Frmat(item.Value) }; });
                }
                else
                {
                    selectList = sv.GetAll().Select(p => { var item = p.GetItemValue(); return new SelectListItem() { Text = item.Display, Value = "{0}".Frmat(item.Value) }; });
                }
            }
            return DropDownListFor(expression, optionLabel, selectList, htmlAttributes);
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
