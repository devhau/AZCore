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
    [TableColumn(Title = "Mã hóa đơn ", FieldName = "ChangeBillCode", Width = 100)]
    [TableColumn(Title = "Tháng thuê trọ", FieldName = "Month", Width = 130)]
    [TableColumn(Title = "Năm thuê trọ", FieldName = "Year", Width = 130)]
    [TableColumn(Title = "Tên dịch vụ", FieldName = "CommonServiceID", DataType = typeof(AZERP.Data.Entities.CommonService), Width = 130)]
    [TableColumn(Title = "Giá", FieldName = "Price", Width = 130)]
    [TableColumn(Title = "Đơn vị", FieldName = "Unit", Width = 130)]
    [TableColumn(Title = "Số tháng trước", FieldName = "NumberBefore", Width = 130)]
    [TableColumn(Title = "Số hiện tại", FieldName = "NumberCurrent", Width = 130)]
    [TableColumn(Title = "Số lượng", FieldName = "Quantity", Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormChangeBill : ManageModule<ChangeBillService, ChangeBillModel, FormUpdateChangeBill>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string ChangeBillCode { get; set; }
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
        /// Năm
        /// </summary>
        [QuerySearch]
        public decimal? Price { get; set; }
        #endregion
        public FormChangeBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý hóa đơn lưu động";
        }
    }
}
