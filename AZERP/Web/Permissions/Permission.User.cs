using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    { /// <summary>
      /// Quyền quản lý User
      /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Quản lý User", OrderIndex = 1)]
        public const string User = "8489B07C-579E-4C63-9905-6EEBBD5A12AC";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Thêm mới", OrderIndex = 1)]
        public const string User_Add = "6a8632ff-38d3-4734-bf4e-5880a61bf7f3";
        /// <summary>
        /// Quyền chỉnh sửa User
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Sửa", OrderIndex = 1)]
        public const string User_Edit = "e777e640-943a-49f5-b85b-766fbc39152d";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xóa", OrderIndex = 1)]
        public const string User_Remove = "ab041778-eeec-4b5a-95ab-e30cf478900a";
        /// <summary>
        /// Quyền xuất excel danh sách User
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Xuất excel", OrderIndex = 1)]
        public const string User_Export = "eb250ac4-f2a2-44ce-a755-e79cf0face38";
        /// <summary>
        /// Quyền nhập excel danh sách User
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Nhập excel", OrderIndex = 1)]
        public const string User_Import = "569e0e8a-f309-4152-a28c-d3b6c8ffc1b3";
        /// <summary>
        /// Quyền đổi mật khẩu của người khác
        /// </summary>
        [Field(GroupName = Group_Common, GroupIndex = Group_Common_Index,Display = "Đổi mật khẩu", OrderIndex = 1)]
        public const string User_ChangePassword = "f125c1da-5382-4ca4-a6b7-01a7d1d6b2a5";
    }
}
