using AZCore.Database.Attributes;
using AZCore.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace AZCore.Database.Enums
{
    public static class OperatorSQLExtend{
        private static List<FieldAttribute> cache;
        public static List<FieldAttribute> GetListOperatorSQL()
        {
            return cache?? (cache=typeof(OperatorSQL).GetEnumValues().Cast<OperatorSQL>().Select(p => { var ep = p.GetType().GetAttribute<FieldAttribute>(); ep.Value = p; return ep; }).ToList());
        }
    }
    public enum OperatorSQL
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "LIKE %%", Name = "like")]
        LIKE,
        [Field(Display = "Not LIKE %%", Name = "not-like")]
        NotLIKE,
        [Field(Display = "IN (1,2,3)", Name = "in")]
        IN,
        [Field(Display = "=",Name = "equals")]
        EQUAL,
        [Field(Display = "=",Name = "not-equals")]
        NotEQUAL,
        [Field(Display = "=",Name = "less-than")]
        LessThan,
        [Field(Display = "=",Name = "greater-than")]
        GreaterThan,
        [Field(Display = "=",Name = "less-than-or-equal")]
        LessThanOrEqual,
        [Field(Display = "=",Name = "greater-than-or-equal")]
        GreaterThanOrEqual,
        [Field(Display = "=",Name = "contains")]
        Contains,
        [Field(Display = "=", Name = "starts-with")]
        StartsWith,
        [Field(Display = "=", Name = "ends-with")]
        EndsWith
    }
}
