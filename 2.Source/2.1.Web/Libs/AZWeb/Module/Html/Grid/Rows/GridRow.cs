﻿using System;

namespace AZWeb.Module.Html.Grid
{
    public class GridRow<T> : IGridRow<T>
    {
        public T Model { get; }
        public Int32 Index { get; }

        public GridHtmlAttributes? Attributes { get; set; }

        public GridRow(T model, Int32 index)
        {
            Index = index;
            Model = model;
        }
    }
}
