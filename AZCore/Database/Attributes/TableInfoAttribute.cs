using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Attributes
{
    public class TableInfoAttribute: Attribute
    {
        public string TableName { get; set; }
    }
}
