using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AZCore.Extensions
{
    public static class ListExtensions
    {
        public static void ForEach<TModel>(this IEnumerable<TModel> models,Action<TModel> acc)
        {
            models.ToList().ForEach(acc);
        }
    }
}
