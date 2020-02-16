using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common.Module
{
    public interface IModule
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        HttpContext httpContext { get; }
        ModuleBase InitModule(HttpContext httpContext);
    }
}
