﻿using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.CompanyWorker
{
    [TableColumn(Title = "Tên công ty", FieldName = "Name")]
    [TableColumn(Title = "Tên viết tắt", FieldName = "AbbreviatedName")]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address", Width = 250)]
    [TableColumn(Title = "Khu vực", FieldName = "AtAddress", Width = 150, DataType = typeof(AddressWorker))]
    [TableColumn(Title = "Mô tả", FieldName = "Description")]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    public class FormCompanyWorker : ManageModule<CompanyWorkerService, CompanyWorkerModel, FormUpdateCompanyWorker>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên công ty
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Tên viết tắt
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string AbbreviatedName { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Address { get; set; }
        /// <summary>
        /// Công ty ở khu vực nào
        /// </summary>
        [QuerySearch]
        public AddressWorker? AtAddress { get; set; }
        #endregion

        public FormCompanyWorker(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý công ty thuê công nhân";
        }
    }
}
