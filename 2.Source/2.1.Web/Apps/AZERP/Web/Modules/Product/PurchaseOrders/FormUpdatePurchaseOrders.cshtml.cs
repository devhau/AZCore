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

namespace AZERP.Web.Modules.Product.PurchaseOrders
{
    public class FormUpdatePurchaseOrders : UpdateModule<PurchaseOrderService, PurchaseOrderModel>
    {
        public FormUpdatePurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
