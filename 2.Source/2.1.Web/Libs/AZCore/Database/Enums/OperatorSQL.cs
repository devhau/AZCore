using AZCore.Database.Attributes;
using AZCore.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace AZCore.Database.Enums
{
    public class ItemOperator { 
        public string Item { get; set; }
        public object Value { get; set; }
        public OperatorSQL Operator { get; set; }

        public static ItemOperator Parse(string item, object value) {
            int? ib = item?.IndexOf('-');

            if (ib != null && ib > 0) {

                var op = OperatorSQLExtend.OperatorSQLs().FirstOrDefault(p => item.Substring(ib.Value + 1).Equals(p.Name))?.Value.As<OperatorSQL>();
                if (op != null) {
                    return new ItemOperator()
                    {
                        Item = item.Substring(0, ib.Value),
                        Operator = op.Value,
                        Value = value
                    };
                }
            }
            return null;
        }
    }
    public static class OperatorSQLExtend{
        private static List<FieldAttribute> cache;
        public static List<FieldAttribute> OperatorSQLs()
        {
            return cache?? (cache=typeof(OperatorSQL).GetEnumValues().Cast<OperatorSQL>().Select(p => { var ep = p.GetAttributeByEnum<FieldAttribute>(); ep.Value = p; return ep; }).ToList());
        }
    }
    public enum OperatorSQL
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "{1} LIKE {0}", GroupName = "%{0}%",Name = "like")]
        LIKE,
        [Field(Display = "{1} Not LIKE {0}", GroupName = "%{0}%", Name = "not-like")]
        NotLIKE,
        [Field(Display = "{1} IN ({0})", GroupName = "{0}", Name = "in")]
        IN,
        [Field(Display = "{1} = {0}", GroupName = "{0}", Name = "equals")]
        EQUAL,
        [Field(Display = "{1} <> {0}", GroupName = "{0}", Name = "not-equals")]
        NotEQUAL,
        [Field(Display = "{1} < {0}", GroupName = "{0}", Name = "less-than")]
        LessThan,
        [Field(Display = "{1} > {0}", GroupName = "{0}", Name = "greater-than")]
        GreaterThan,
        [Field(Display = "{1} <= {0}", GroupName = "{0}", Name = "less-than-or-equal")]
        LessThanOrEqual,
        [Field(Display = "{1} => {0}", GroupName = "{0}", Name = "greater-than-or-equal")]
        GreaterThanOrEqual,
        [Field(Display = "{1} LIKE {0}", GroupName = "%{0}%", Name = "contains")]
        Contains,
        [Field(Display = "{1} LIKE {0}", GroupName = "{0}%", Name = "starts-with")]
        StartsWith,
        [Field(Display = "{1} LIKE {0}", GroupName = "%{0}", Name = "ends-with")]
        EndsWith
    }
}
