using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BotYoutube.Database.Attr
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        public bool IsAutoIncrement { get; set; } = false;
        public bool IsKey { get; set; } = false;
        public string FieldName { get; set; }
        public string FieldDisplay { get; set; }
        public SqlDbType? FieldType { get; set; }
        public bool IsNull { get; set; } = true;
        public int Length { get; set; } = 0;
        public Object Value { get; set; }
        public Object ValueDefault { get; set; }
        
    }
}
