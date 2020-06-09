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

namespace AZERP.Web.Modules.Hotel.Contract
{
    [TableColumn(Title = "Mã hợp đồng ", FieldName = "Code", Width = 150)]
    [TableColumn(Title = "Tên hợp đồng", FieldName = "Name", Width = 150)]
    [TableColumn(Title = "Chủ nhà", FieldName = "BossID", Width = 130)]
    [TableColumn(Title = "Người thuê", FieldName = "RenterID", DataType = typeof(RenterService), Width = 130)]
    [TableColumn(Title = "Phòng trọ", FieldName = "HotelID" , DataType = typeof(HotelService), Width = 150)]
    [TableColumn(Title = "Tiền đặt cọc", FieldName = "Deposit", Width = 150)]
    [TableColumn(Title = "Số bạn", FieldName = "Quantity", Width = 100)]
    [TableColumn(Title = "Loại hợp đồng", FieldName = "TypeOfContract" , DataType = typeof(TypeOfContract), Width = 150)]
    [TableColumn(Title = "Thời gian bắt đầu", FieldName = "TimeStart", Width = 200)]
    [TableColumn(Title = "Thời gian kết thúc", FieldName = "TimeEnd", Width = 200)]
    [TableColumn(Title = "Trạng thái", FieldName = "ContractStatus", DataType = typeof(TypeOfContractStatus), Width = 200)]
    [TableColumn(Title = "Ghi Chú", FieldName = "Note")]

    public class FormContract : ManageModule<ContractService, ContractModel, FormUpdateContract>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã hợp đồng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? Code { get; set; }
        /// <summary>
        /// Tên hợp đồng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Phòng trọ
        /// </summary>
        [QuerySearch]
        public long? HotelID { get; set; }
        /// <summary>
        /// Người thuê nhà
        /// </summary>
        [QuerySearch]
        public long? RenterID { get; set; }
        /// <summary>
        /// Loại hợp đồng
        /// </summary>
        [QuerySearch]
        public TypeOfContract? TypeOfContract { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        [QuerySearch]
        public TypeOfContractStatus? TypeOfContractStatus { get; set; }
        #endregion

        public FormContract(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách hợp đồng";
        }
    }
}
