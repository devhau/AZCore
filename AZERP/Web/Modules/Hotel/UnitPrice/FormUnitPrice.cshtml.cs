using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZERP.Data.Enums;
using AZERP.Web.Modules.Hotel.UnitPrice;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.UnitPrice
{
    [TableColumn(Title = "Mã đơn giá ", FieldName = "UnitPriceID", Width = 100)]
    [TableColumn(Title = "Tiền điện", FieldName = "ElectricityCharge", Width = 130)]
    [TableColumn(Title = "Tiền nước", FieldName = "WaterCharge", Width = 130)]
    [TableColumn(Title = "Tiền khác", FieldName = "ChargeOther", Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormUnitPrice : ManageModule<UnitPriceService, UnitPriceModel, FormUpdateUnitPrice>
    {
        public FormUnitPrice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý đơn giá";
        }
    }
}
