using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
         /// Quyền quản lý Tenant
         /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Quản lý Tenant", OrderIndex = 7)]
        public const string Tenant = "7af51790-78f3-44f3-8945-c60fc0d4c3fa";
        /// <summary>
        /// Quyền thêm mới Tenant
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Thêm mới", OrderIndex = 7)]
        public const string Tenant_Add = "ecd2c02f-c1dd-4ad0-8f82-e45aaf3c8171";
        /// <summary>
        /// Quyền chỉnh sửa Tenant
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Sửa", OrderIndex = 7)]
        public const string Tenant_Edit = "e2fd260b-369b-458c-ab12-6ce89149bd56";
        /// <summary>
        /// Quyền thêm mới Tenant
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xóa", OrderIndex = 7)]
        public const string Tenant_Remove = "b8ed01a5-455c-459d-a0a3-96d5f74dff35";
        /// <summary>
        /// Quyền xuất excel danh sách Tenant
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xuất excel", OrderIndex = 7)]
        public const string Tenant_Export = "d5942693-7243-47f1-a20f-6d3f46bde23c";
        /// <summary>
        /// Quyền nhập excel danh sách Tenant
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Nhập excel", OrderIndex = 7)]
        public const string Tenant_Import = "5b254176-d1a9-4b50-8d0d-0e89ac582daf";
    }
}
