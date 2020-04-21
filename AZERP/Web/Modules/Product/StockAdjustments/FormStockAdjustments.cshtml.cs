using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AZERP.Web.Modules.Product.StockAdjustments
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    public class FormStockAdjustments : ManageModule<StockAdjusmentService, StockAdjusmentModel, FormUpdateStockAdj>
    {
        public FormStockAdjustments(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Kiểm hàng";
        }
        [BindForm]
        public List<StockAdjusmentModel> DataStock { get; set; }
    }
}
