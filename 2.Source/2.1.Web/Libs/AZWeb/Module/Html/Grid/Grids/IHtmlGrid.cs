using Microsoft.AspNetCore.Html;
using System;

namespace AZWeb.Module.Html.Grid
{
    public interface IHtmlGrid<T> : IHtmlContent
    {
        IGrid<T> Grid { get; }

        String PartialViewName { get; set; }
    }
}
