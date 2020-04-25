using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
         /// Quyền quản lý Tenant
         /// </summary>
        [Field(Display = "Quản lý Tenant", OrderIndex = 7)]
        public const string Tenant = "10007";
        /// <summary>
        /// Quyền thêm mới Tenant
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 7)]
        public const string Tenant_Add = "10007001";
        /// <summary>
        /// Quyền chỉnh sửa Tenant
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 7)]
        public const string Tenant_Edit = "10007002";
        /// <summary>
        /// Quyền thêm mới Tenant
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 7)]
        public const string Tenant_Remove = "10007003";
        /// <summary>
        /// Quyền xuất excel danh sách Tenant
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 7)]
        public const string Tenant_Export = "10007004";
        /// <summary>
        /// Quyền nhập excel danh sách Tenant
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 7)]
        public const string Tenant_Import = "10007005";
    }
}
