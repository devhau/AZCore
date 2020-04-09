using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class BindQueryAttribute :  System.Attribute
    {
    }
}
