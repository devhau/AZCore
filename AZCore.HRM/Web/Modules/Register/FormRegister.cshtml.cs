using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Modules.Register
{
    public class FormRegister : ModuleBase
    {
        public FormRegister(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
