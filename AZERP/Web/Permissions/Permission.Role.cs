﻿using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý Role
        /// </summary>
        [Field(Display ="Quản lý role")]
        public const string Role = "10001";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(Display = "Thêm mới role")]
        public const string Role_Add = "10001001";
        /// <summary>
        /// Quyền chỉnh sửa role
        /// </summary>
        [Field(Display = "Chỉ sửa role")]
        public const string Role_Edit = "10001002";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(Display = "Xóa role")]
        public const string Role_Remove = "10001003";
        /// <summary>
        /// Quyền xuất excel danh sách role
        /// </summary>
        [Field(Display = "Export role")]
        public const string Role_Export = "10001004";
        /// <summary>
        /// Quyền nhập excel danh sách role
        /// </summary>
        [Field(Display = "Import role")]
        public const string Role_Import = "10001005";
    }
}
