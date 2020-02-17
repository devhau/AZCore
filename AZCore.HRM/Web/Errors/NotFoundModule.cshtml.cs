using AZCore.Web.Common.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Errors
{
    public class NotFoundModule: ModuleBase
    {
        public IModuleResult Get() {
            this.Title = "Không tìm thấy module";
            return View();
        }
    }
}
