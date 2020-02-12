using AZCore.Extensions;
using AZCore.Web.Common.Module;
using AZCore.Web.Extensions;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common
{
    public class AZPageAjax:AZPage, IAjax
    {
        protected override void RenderView(HttpContext HttpContext)
        {
            HttpContext.Response.WriteAsync(HttpContext.GetContetModule().ToJson());
        }
    }
}
