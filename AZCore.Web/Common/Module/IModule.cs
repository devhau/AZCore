using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public interface IModule
    {
        HttpContext httpContext { get; }
        ModuleBase InitModule(HttpContext httpContext);
    }
}
