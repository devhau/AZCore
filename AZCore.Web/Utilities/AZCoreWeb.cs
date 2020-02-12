using AZCore.Extensions;
using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Utilities
{
    public class AZCoreWeb
    {
        public static IWebHostEnvironment env;
        public const string KeyHtmlModule = "AZHtmlModule";
        public const string KeyUrlVirtual = "AZUrlVirtual";
    }
}
