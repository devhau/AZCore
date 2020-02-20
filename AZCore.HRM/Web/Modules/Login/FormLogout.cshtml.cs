using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Modules.Login
{
    public class FormLogout : ModuleBase
    {
        public FormLogout(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get()
        {
            return View();
        }
    }
}
