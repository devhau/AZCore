using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Attributes
{
    public class ModulePermissionAttribute : AuthAttribute
    {
        public string ViewCode { get; set; }
        public string AddCode { get; set; }
        public string EditCode { get; set; }
        public string RemoveCode { get; set; }
        public string ExportCode { get; set; }
        public string ImportCode { get; set; }
    }
}
