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
    [TableColumn(Title = "Mã Hợp Đồng ", FieldName = "ContractCode", Width = 150)]
    [TableColumn(Title = "Tên Hợp Đồng", FieldName = "ContractName", Width = 150)]
    [TableColumn(Title = "Chủ Nhà", FieldName = "BossID",  Width = 150)]
    [TableColumn(Title = "Người Thuê Nhà", FieldName = "RenterID", DataType = typeof(RenterService), Width = 200)]
    [TableColumn(Title = "Phòng Trọ", FieldName = "HotelID" , DataType = typeof(HotelService), Width = 150)]
    [TableColumn(Title = "Tiền Đặt Cọc", FieldName = "Deposit", Width = 150)]
    [TableColumn(Title = "Số Bạn Cùng Phòng", FieldName = "Quantity", Width = 200)]
    [TableColumn(Title = "Loại Hợp Đồng", FieldName = "TypeOfContract" , DataType = typeof(TypeOfContract), Width = 150)]
    [TableColumn(Title = "Thời Gian Bắt Đầu", FieldName = "TimeStart", Width = 200)]
    [TableColumn(Title = "Thời Gian Kết Thúc", FieldName = "TimeEnd", Width = 200)]
    [TableColumn(Title = "Trạng Thái Hợp Đồng", FieldName = "ContractStatus", DataType = typeof(TypeOfContractStatus), Width = 200)]
    [TableColumn(Title = "Ghi Chú", FieldName = "Note", Width = 75)]

    public class FormContract : ManageModule<ContractService, ContractModel, FormUpdateContract>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã Hợp Đồng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? ContractCode { get; set; }
        /// <summary>
        /// Tên Hợp Đồng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string ContractName { get; set; }
        /// <summary>
        /// Phòng Trọ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? HotelID { get; set; }
        /// <summary>
        /// Người Thuê Nhà
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? RenterID { get; set; }

        #endregion


        public FormContract(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hợp đồng";
        }

        //public CommonServiceModel getService(long Id)
        //{
        ////    return this.commonService.Select(p => p.Id == Id).FirstOrDefault();
        //}
    }
}
