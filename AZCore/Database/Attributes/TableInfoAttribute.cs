using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableInfoAttribute: Attribute
    {
        public string TableName { get; set; }
    }
}
