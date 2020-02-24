using AZCore.Extensions;
using AZWeb.Common.Module;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Utilities
{
    public class AZCoreWeb
    {
        public static IWebHostEnvironment env;
        public const string KeyHtmlModule = "AZHtmlModule";
        public const string KeyUrlVirtual = "AZUrlVirtual";
    }
}
