using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.ChangeBill
{
    [TableColumn(Title = "Mã hóa đơn ", FieldName = "Code", Width = 100)]
    [TableColumn(Title = "Tên phòng trọ", FieldName = "HotelID", DataType =typeof(HotelService), Width = 130)]
    [TableColumn(Title = "Tháng thuê trọ", FieldName = "Month", Width = 130)]
    [TableColumn(Title = "Năm thuê trọ", FieldName = "Year", Width = 130)]
    [TableColumn(Title = "Tên dịch vụ", FieldName = "CommonServiceID", DataType = typeof(AZERP.Data.Entities.CommonService), Width = 130)]
    [TableColumn(Title = "Giá", FieldName = "Price", FormatString = "{0:#,###}", Width = 120)]
    [TableColumn(Title = "Đơn vị", FieldName = "Unit", Width = 100)]
    [TableColumn(Title = "Số tháng trước", FieldName = "NumberBefore", Width = 120)]
    [TableColumn(Title = "Số hiện tại", FieldName = "NumberCurrent", Width = 120)]
    [TableColumn(Title = "Số lượng", FieldName = "Quantity", Width = 100)]
    [TableColumn(Title = "Trạng thái", FieldName = "StatusBill",DataType =typeof(BillStatus), Width = 100)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormChangeBill : ManageModule<ChangeBillService, ChangeBillModel, FormUpdateChangeBill>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Code { get; set; }
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [QuerySearch]
        public long? HotelID { get; set; }
        /// <summary>
        /// Tháng
        /// </summary>
        [QuerySearch]
        public Month? Month { get; set; }
        /// <summary>
        /// Năm
        /// </summary>
        [QuerySearch]
        public int? Year { get; set; }
        /// <summary>
        /// Tên dịch vụ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string ServiceName { get; set; }
        /// <summary>
        /// Giá
        /// </summary>
        [QuerySearch]
        public decimal? Price { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        [QuerySearch]
        public BillStatus? StatusBill { get; set; }
        #endregion
        public FormChangeBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách hóa đơn lưu động";
        }
    }
}
