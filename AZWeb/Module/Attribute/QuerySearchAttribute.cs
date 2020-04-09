using AZCore.Database;
using AZCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AZWeb.Module.Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class QuerySearchAttribute : BindQueryAttribute
    {
        public EnumOperatorSQL OperatorSQL { get; set; } = EnumOperatorSQL.EQUAL;
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
