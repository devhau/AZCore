﻿using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Payment
{
    public class FormUpdatePayment : UpdateModule<PaymentService, PaymentModel>
    {
        public FormUpdatePayment(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thanh toán";
        }

    }
}
