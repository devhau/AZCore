using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class FieldAutoGenCodeAttribute: Attribute
    {
        public object Key { get; set; }
    }
}
