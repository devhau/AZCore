using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.TotalBill
{
    [TableColumn(Title = "Mã hóa đơn ", FieldName = "Code", Width = 100)]
    [TableColumn(Title = "Tên hóa đơn ", FieldName = "Name", Width = 100)]
    [TableColumn(Title = "Mã đơn cố định", FieldName = "FixedBillID", DataType = typeof(FixedBillService), Width = 130)]
    [TableColumn(Title = "Mã đơn lưu động", FieldName = "ChangeBillID", DataType = typeof(ChangeBillService), Width = 130)]
    [TableColumn(Title = "Tổng tiền", FieldName = "TotalPricess", FormatString = "{0:#,###}", Width = 130)]
    [TableColumn(Title = "Tiền nợ", FieldName = "Debt", FormatString = "{0:#,###}", Width = 130)]
    [TableColumn(Title = "Thời hạn nộp", FieldName = "Deadline", Width = 130)]
    [TableColumn(Title = "Trạng thái", FieldName = "StatusBill", DataType = typeof(BillStatus), Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormTotalBill : ManageModule<TotalBillService, TotalBillModel, FormUpdateTotalBill>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên hóa đơn
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Thời hạn nộp
        /// </summary>
        [QuerySearch]
        public DateTime? Deadline { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [QuerySearch]
        public BillStatus? BillStatus { get; set; }
        /// <summary>
        /// Tổng tiền
        /// </summary>
        [QuerySearch]
        public decimal? TotalPricess { get; set; }
        #endregion
        public FormTotalBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách hóa đơn tổng";
        }
    }
}
