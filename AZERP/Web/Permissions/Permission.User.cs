using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    { /// <summary>
      /// Quyền quản lý User
      /// </summary>
        [Field(Display = "Quản lý User", OrderIndex = 1)]
        public const string User = "10002";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(Display = "Thêm mới User", OrderIndex = 1)]
        public const string User_Add = "10002001";
        /// <summary>
        /// Quyền chỉnh sửa User
        /// </summary>
        [Field(Display = "Chỉ sửa User", OrderIndex = 1)]
        public const string User_Edit = "10002002";
        /// <summary>
        /// Quyền thêm mới User
        /// </summary>
        [Field(Display = "Xóa User", OrderIndex = 1)]
        public const string User_Remove = "10002003";
        /// <summary>
        /// Quyền xuất excel danh sách User
        /// </summary>
        [Field(Display = "Export User", OrderIndex = 1)]
        public const string User_Export = "10002004";
        /// <summary>
        /// Quyền nhập excel danh sách User
        /// </summary>
        [Field(Display = "Import User", OrderIndex = 1)]
        public const string User_Import = "10002005";
    }
}
