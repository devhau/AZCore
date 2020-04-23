using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZERP.Data.Enums;
using AZERP.Web.Modules.Hotel.Area;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Hotel
{
    [TableColumn(Title = "Tên phòng", FieldName = "HotelName", Width = 100)]
    [TableColumn(Title = "Tên khu vực", FieldName = "AreaID", Width = 150,DataType =typeof(AreaService))]
    [TableColumn(Title = "Loại phòng trọ", FieldName = "TypeOfHotelID", Width = 150, DataType = typeof(TypeOfHotelService))]
    [TableColumn(Title = "Trạng thái", FieldName = "HotelStatus", Width =200, DataType = typeof(HotelStatus))]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormHotel : ManageModule<HotelService, HotelModel, FormUpdateHotel>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string HotelName { get; set; }
        /// <summary>
        /// Loại phòng trọ
        /// </summary>
        [QuerySearch]
        public string TypeOfHotel { get; set; }
        /// <summary>
        /// Khu vực
        /// </summary>
        [QuerySearch]
        public string Area { get; set; }
        /// <summary>
        /// Trạng thái của phòng trọ
        /// </summary>
        [QuerySearch]
        public HotelStatus? HotelStatus { get; set; }
        #endregion

        public FormHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý phòng trọ";
        }
    }
}
