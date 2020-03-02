﻿using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Home
{
    [Auth]
    public class FormHome:ModuleBase
    {
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public string id { get; set; }
        public object Get(){
           return View();
        }
    }
}
