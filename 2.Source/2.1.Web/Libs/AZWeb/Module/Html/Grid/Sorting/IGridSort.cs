using System;

namespace AZWeb.Module.Html.Grid
{
    public interface IGridSort<T> : IGridProcessor<T>
    {
        IGrid<T> Grid { get; set; }

        (Int32 Index, GridSortOrder Order)? this[IGridColumn<T> column] { get; }
    }
}
