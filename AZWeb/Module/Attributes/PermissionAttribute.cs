using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attributes
{
    public class PermissionAttribute : AuthAttribute
    {
        public string PermissionCode { get; set; }
        public string Message { get; set; }
    }
}
