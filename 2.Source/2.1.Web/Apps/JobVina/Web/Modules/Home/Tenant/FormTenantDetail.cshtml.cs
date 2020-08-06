﻿using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home.Tenant
{
    public class FormTenantDetail : PageHome
    {
        [BindService]
        public TenantService TenantService;
        public FormTenantDetail(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        public IView Get(long Id) {
           var tenant= TenantService.GetById(Id);
            if (tenant != null)
            {
                this.Title = tenant.Name;
                this.Description = tenant.Description;

                return View(tenant);
            }
            return GoToHome();
        }
    }
}
