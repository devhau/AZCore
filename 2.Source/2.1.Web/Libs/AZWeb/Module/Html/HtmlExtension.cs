using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
namespace AZWeb.Module.Html
{
    public static class HtmlExtension
    {
       
        public static ZHtml<TModel> ZHtml<TModel>(this IHtmlHelper<TModel> html) {
            return new ZHtml<TModel>(html);
        }
        public static ZHtml ZHtml(this IHtmlHelper html)
        {
            return new ZHtml(html);
        }
    }
}
