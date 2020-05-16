using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.RoomService
{
    [TableColumn(Title = "Mã dịch vụ ", FieldName = "RoomServiceID", Width = 180)]
    [TableColumn(Title = "Mã phòng trọ", FieldName = "RegionalServiceID", Width = 180, DataType = typeof(AZERP.Data.Entities.RegionalService))]
    [TableColumn(Title = "Đơn giá", FieldName = "Price", Width = 180)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormRoomService : ManageModule<AZERP.Data.Entities.RoomService, RoomServiceModel, FormUpdateRoomService>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã dịch vụ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? RegionalServiceID { get; set; }
        [QuerySearch]
        /// <summary>
        /// Giá
        /// </summary>
        public decimal? Price { get; set; }
        [QuerySearch]
        /// <summary>
        /// Mã phòng
        /// </summary>
        public long RoomServiceID { get; set; }
        #endregion
        [QuerySearch]
        /// <summary>
        /// Mã phòng
        /// </summary>
        public string RoomServiceName { get; set; }

        public FormRoomService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách dịch vụ phòng";
        }
    }
}
