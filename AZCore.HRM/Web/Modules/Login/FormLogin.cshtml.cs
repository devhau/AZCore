using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.HRM.Web.Modules.Login
{
    public class FormLogin:ModuleBase
    {
        public FormLogin(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public IViewResult Get() {
            this.Title = "Đăng nhập hệ thống";
            this.IsTheme = false;
            return View();
        }
    }
}
