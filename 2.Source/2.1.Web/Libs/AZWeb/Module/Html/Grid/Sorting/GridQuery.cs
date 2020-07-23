﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace AZWeb.Module.Html.Grid
{
    public sealed class GridQuery : ExpressionVisitor
    {
        private Boolean Ordered { get; set; }

        private GridQuery()
        {
        }

        public static Boolean IsOrdered(IQueryable models)
        {
            GridQuery expression = new GridQuery();
            expression.Visit(models.Expression);

            return expression.Ordered;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(Queryable) &&
                (node.Method.Name == nameof(Queryable.OrderBy) || node.Method.Name == nameof(Queryable.OrderByDescending)))
            {
                Ordered = true;

                return node;
            }

            return base.VisitMethodCall(node);
        }
    }
}
