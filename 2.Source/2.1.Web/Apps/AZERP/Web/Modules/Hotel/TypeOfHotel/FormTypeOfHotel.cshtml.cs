using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.TypeOfHotel
{
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
