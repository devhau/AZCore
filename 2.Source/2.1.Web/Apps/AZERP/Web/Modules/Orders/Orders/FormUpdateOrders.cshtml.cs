using AZCore.Database;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AZERP.Web.Modules.Orders.Orders
{
    public class FormUpdateOrders : UpdateModule<PurchaseOrderService, PurchaseOrderModel>
    {
        public FormUpdateOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
