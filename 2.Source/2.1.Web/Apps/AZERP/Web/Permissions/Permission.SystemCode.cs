using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý System Code
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Quản lý System Code", OrderIndex = 2)]
        public const string SystemCode = "f47cc7a5-077d-4cea-9edc-442f774e4869";
        /// <summary>
        /// Quyền thêm mới SystemCode
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Thêm mới", OrderIndex = 2)]
        public const string SystemCode_Add = "acd131c8-8e60-4323-94b6-f7a159159a6e";
        /// <summary>
        /// Quyền chỉnh sửa SystemCode
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Sửa", OrderIndex = 2)]
        public const string SystemCode_Edit = "00c49348-7c93-4519-8d8b-cc945332daf1";
        /// <summary>
        /// Quyền thêm mới SystemCode
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xóa", OrderIndex = 2)]
        public const string SystemCode_Remove = "392f84b9-13e0-4936-a08d-007fad4f6c92";
        /// <summary>
        /// Quyền xuất excel danh sách SystemCode
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xuất excel", OrderIndex = 2)]
        public const string SystemCode_Export = "d9339c42-6cab-46b5-8b4c-a98a5a5476d2";
        /// <summary>
        /// Quyền nhập excel danh sách SystemCode
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Nhập excel", OrderIndex = 2)]
        public const string SystemCode_Import = "d2623f28-fd30-4bbb-8b64-fc55150eadeb";
    }
}
