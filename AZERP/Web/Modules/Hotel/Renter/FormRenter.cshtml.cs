using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AZERP.Web.Modules.Hotel.Renter
{
    [TableColumn(Title = "Mã người thuê ", FieldName = "RenterID", Width = 150)]
    [TableColumn(Title = "Tên người thuê", FieldName = "RenterName", Width = 150)]
    [TableColumn(Title = "Số CMND/CCCD", FieldName = "CMND", Width = 200)]
    [TableColumn(Title = "Số bạn cùng phòng", FieldName = "Quantity", Width = 200)]
    [TableColumn(Title = "Tên phòng trọ", FieldName = "HotelID", Width = 200, DataType = typeof(HotelService))]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormRenter : ManageModule<RenterService, RenterModel, FormUpdateRenter>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string RenterName { get; set; }
        #endregion

        public FormRenter(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý người thuê trọ";
        }
    }
}
