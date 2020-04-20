using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZERP.Data.Enums;
using AZERP.Web.Modules.Hotel.Area;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Area
{
    [TableColumn(Title = "Mã khu vực", FieldName = "AreaID", Width = 100)]
    [TableColumn(Title = "Tên khu vực", FieldName = "AreaName", Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note", Width = 80)]

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
