using System;
using System.Data;

namespace AZCore.Database.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FieldAttribute : FieldTitleAttribute
    {
        public bool IsAutoIncrement { get; set; } = false;
        public bool IsKey { get; set; } = false;
        public string Name { get; set; }
        public SqlDbType? FieldType { get; set; }
        public bool IsNull { get; set; } = true;
        public int Length { get; set; } = 0;
        public int OrderIndex { get; set; }
        public Object Value { get; set; }
        public Object ValueDefault { get; set; }
        public Type TargetService { get; set; }
    }
}
