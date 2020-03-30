using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Attr
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldValueAttribute : Attribute
    {
        public int GroupIndex { get; set; }
    }
}
