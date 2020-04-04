﻿using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Role
{
    public class FormUpdateRole : UpdateModule<RoleService, RoleModel>
    {
        public FormUpdateRole(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }

    }
}