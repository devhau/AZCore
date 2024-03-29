﻿using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormSearchJob : PageModule
    {

        public FormSearchJob(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        public IView Get()
        {
            this.Title = "Tìm việc làm tại các khu công nghiệp";
            return View();
        }
    }
}
