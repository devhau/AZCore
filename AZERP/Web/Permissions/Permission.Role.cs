using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý Role
        /// </summary>
        [Field(Display ="Quản lý role", OrderIndex = 2)]
        public const string Role = "10003";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 2)]
        public const string Role_Add = "10003001";
        /// <summary>
        /// Quyền chỉnh sửa role
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 2)]
        public const string Role_Edit = "10003002";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 2)]
        public const string Role_Remove = "10003003";
        /// <summary>
        /// Quyền xuất excel danh sách role
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 2)]
        public const string Role_Export = "10003004";
        /// <summary>
        /// Quyền nhập excel danh sách role
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 2)]
        public const string Role_Import = "10003005";
    }
}
