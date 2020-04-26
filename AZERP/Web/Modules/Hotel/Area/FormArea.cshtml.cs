using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Area
{
    [TableColumn(Title = "Mã khu vực ", FieldName = "AreaID", Width = 100)]
    [TableColumn(Title = "Tên khu vực", FieldName = "AreaName", Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormArea : ManageModule<AreaService, AreaModel, FormUpdateArea>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string AreaName { get; set; }
        #endregion

        public FormArea(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý khu vực";
        }
    }
}
