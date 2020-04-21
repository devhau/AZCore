using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Orders.Orders
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    public class FormOrders : ManageModule<OrderService, OrderModel, FormUpdateOrders>
    {
        public FormOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Đơn hàng";
        }
    }
}
