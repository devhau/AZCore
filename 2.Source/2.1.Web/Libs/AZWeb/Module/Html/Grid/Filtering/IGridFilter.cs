using Microsoft.Extensions.Primitives;
using System;
using System.Linq.Expressions;

namespace AZWeb.Module.Html.Grid
{
    public interface IGridFilter
    {
        String? Method { get; set; }
        StringValues Values { get; set; }
        GridFilterCase Case { get; set; }

        Expression? Apply(Expression expression);
    }
}
