﻿using System;

namespace AZWeb.Module.Html.Grid
{
    public interface IGridRow<out T>
    {
        T Model { get; }
        Int32 Index { get; }

        GridHtmlAttributes? Attributes { get; set; }
    }
}
