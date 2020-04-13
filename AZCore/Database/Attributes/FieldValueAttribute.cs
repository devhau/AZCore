using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldValueAttribute : Attribute
    {
        public int GroupIndex { get; set; }
    }
}
