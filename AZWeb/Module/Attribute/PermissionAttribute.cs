using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attribute
{
    public class PermissionAttribute : AuthAttribute
    {
        public string PermissionCode { get; set; }
    }
}
