﻿using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Orders.Orders
{
    public class FormUpdateOrders : UpdateModule<OrderService, OrderModel>
    {
        public FormUpdateOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa đơn hàng";
        }
    }
}