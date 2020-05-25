using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class QuerySearchAttribute : BindQueryAttribute
    {
        public OperatorSQL OperatorSQL { get; set; } = OperatorSQL.EQUAL;
        public PropertyInfo Property { get; set; }
    }
    public static class QuerySearchExtend {

        public static IEnumerable<QuerySearchAttribute> GetPropertyByQuerySearch(this Type type)
        {
            return type.GetProperties().Select(p=> {
                var rs = p.GetAttribute<QuerySearchAttribute>();
                if (rs != null) rs.Property = p;
                return rs;
            }).Where(p=>p!=null);
        }
    }
}
