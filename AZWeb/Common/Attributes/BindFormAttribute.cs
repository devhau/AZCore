using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class BindFormAttribute : Attribute
    {
    }
}
