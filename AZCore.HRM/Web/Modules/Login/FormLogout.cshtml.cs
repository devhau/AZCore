using AZCore.Web.Common.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Modules.Login
{
    public class FormLogout : ModuleBase
    {
        public IModuleResult Get()
        {
            return View();
        }
    }
}
