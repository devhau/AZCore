using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý Role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display ="Quản lý role", OrderIndex = 2)]
        public const string Role = "FD82050D-6FCF-436B-B1EB-2B942088F06F";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Thêm mới", OrderIndex = 2)]
        public const string Role_Add = "725dbafd-a763-42f2-b00f-6eab0faa1662";
        /// <summary>
        /// Quyền chỉnh sửa role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Sửa", OrderIndex = 2)]
        public const string Role_Edit = "ea4a7ca8-daf1-42a3-9fe6-36e466e873f4";
        /// <summary>
        /// Quyền thêm mới role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xóa", OrderIndex = 2)]
        public const string Role_Remove = "341f7de3-72ba-4e32-b693-e50469eecd70";
        /// <summary>
        /// Quyền xuất excel danh sách role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xuất excel", OrderIndex = 2)]
        public const string Role_Export = "11fe23c8-a6b8-49cd-adb1-1a50af24a31f";
        /// <summary>
        /// Quyền nhập excel danh sách role
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Nhập excel", OrderIndex = 2)]
        public const string Role_Import = "90fc285b-9093-4497-8773-fc9c0291c034";
    }
}
