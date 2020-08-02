using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldTitleAttribute : Attribute
    {
        public string GroupName { get; set; }
        public int GroupIndex { get; set; }
        public string Display { get; set; }
    }
}
