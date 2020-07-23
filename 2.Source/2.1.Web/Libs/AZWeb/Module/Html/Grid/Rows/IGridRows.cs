using System;
using System.Collections.Generic;

namespace AZWeb.Module.Html.Grid
{
    public interface IGridRows<out T> : IEnumerable<IGridRow<T>>
    {
    }

    public interface IGridRowsOf<T> : IGridRows<T>
    {
        IGrid<T> Grid { get; }

        Func<T, Object>? Attributes { get; set; }
    }
}
