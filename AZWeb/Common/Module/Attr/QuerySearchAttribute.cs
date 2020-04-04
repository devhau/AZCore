using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AZWeb.Common.Module.Attr
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
