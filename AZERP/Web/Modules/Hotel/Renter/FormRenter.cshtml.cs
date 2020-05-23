using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AZERP.Web.Modules.Hotel.Renter
{
    [TableColumn(Title = "Mã Người Thuê ", FieldName = "RenterCode", Width = 150)]
    [TableColumn(Title = "Tên Người Thuê", FieldName = "RenterName", Width = 150)]
    [TableColumn(Title = "Địa Chỉ", FieldName = "Address", Width = 300)]
    [TableColumn(Title = "Số CMND/CCCD", FieldName = "CMND", Width = 200)]
    [TableColumn(Title = "Số Điện Thoại", FieldName = "Tel", Width = 200)]
    [TableColumn(Title = "Ghi Chú", FieldName = "Note")]

    public class FormRenter : ManageModule<RenterService, RenterModel, FormUpdateRenter>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên người thuê
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string RenterName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch]
        public int? Tel { get; set; }
        #endregion

        public FormRenter(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh Sách Người Thuê Trọ";
        }
    }
}
