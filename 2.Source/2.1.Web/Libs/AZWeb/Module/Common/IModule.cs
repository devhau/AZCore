using AZCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public interface IModule: IAZTransient
    {
        HttpContext HttpContext { get; }
    }
}
