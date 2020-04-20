using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZERP.Data.Enums;
using AZERP.Web.Modules.Hotel.TypeOfHotel;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.TypeOfHotel
{
    [TableColumn(Title = "Mã loại phòng trọ ", FieldName = "TypeOfHotelID", Width = 180)]
    [TableColumn(Title = "Loại phòng trọ", FieldName = "TypeOfHotelName", Width = 180)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormTypeOfHotel : ManageModule<TypeOfHotelService, TypeOfHotelModel, FormUpdateTypeOfHotel>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string TypeOfHotelName { get; set; }
        #endregion

        public FormTypeOfHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý loại phòng trọ";
        }
    }
}
