using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AZWeb.Module.Html
{
    public static class HtmlHelper
    {

        public static IHtmlContent CheckBoxFor<TModel>(this IHtmlHelper Html, TModel Model, Expression<Func<TModel, bool>> expression, object htmlAttributes) {
            return null;
        }
        public static IHtmlContent DropDownListFor<TModel, TResult>(this IHtmlHelper Html, TModel Model, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes) {
            return null;
        }
        public static IHtmlContent EditorFor<TModel, TResult>(this IHtmlHelper Html, TModel Model, Expression<Func<TModel, TResult>> expression, string templateName, string htmlFieldName, object additionalViewData) {
            return null;
        }
        public static IHtmlContent HiddenFor<TModel, TResult>(this IHtmlHelper Html, TModel Model, Expression<Func<TModel, TResult>> expression, object htmlAttributes)
        {
            return null;
        }
        public static IHtmlContent LabelFor<TModel, TResult>(this IHtmlHelper Html, TModel Model, Expression<Func<TModel, TResult>> expression, string labelText, object htmlAttributes)
        {
            return null;
        }
        public static IHtmlContent ListBoxFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return null;
        }
        public static string NameFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression)
        {
            return null;
        }
        public static IHtmlContent PasswordFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, object htmlAttributes)
        {
            return null;
        }
        public static IHtmlContent RadioButtonFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, object value, object htmlAttributes)
        {
            return null;
        }
        public static IHtmlContent TextAreaFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, int rows, int columns, object htmlAttributes)
        {
            return null;
        }
        public static IHtmlContent TextBoxFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, string format, object htmlAttributes)
        {
            return Html.TextBox("", expression.Compile()(Model));
        }
        public static IHtmlContent ValidationMessageFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, string message, object htmlAttributes, string tag)
        {
            return null;
        }
        public static string ValueFor<TModel, TResult>(this IHtmlHelper Html, TModel Model,Expression<Func<TModel, TResult>> expression, string format)
        {
            return null;
        }
    }
}
