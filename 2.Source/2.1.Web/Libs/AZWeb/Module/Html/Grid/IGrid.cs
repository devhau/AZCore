using Microsoft.AspNetCore.Http;
using System;

namespace AZWeb.Module.Html.Grid
{
    public interface IGrid
    {
        String Url { get; set; }
        String Id { get; set; }
        String Name { get; set; }
        String EmptyText { get; set; }

        IQueryCollection Query { get; set; }
    }

    public interface IGrid<T> : IGrid
    {
    }
}
