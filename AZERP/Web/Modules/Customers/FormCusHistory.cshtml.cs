using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;

namespace AZERP.Web.Modules.Customers
{
    public class FormCusHistory : ManageModule<CustomersService, CustomersModel>
    {

        public FormCusHistory(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Lịch sử mua hàng";
        }
    }
}
