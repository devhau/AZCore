using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    { /// <summary>
      /// Quyền quản lý Cus
      /// </summary>
        [Field(Display = "Quản lý khách hàng", OrderIndex = 1)]
        public const string Cus = "10009";
        /// <summary>
        /// Quyền thêm mới Cus
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 1)]
        public const string Cus_Add = "10009001";
        /// <summary>
        /// Quyền chỉnh sửa Cus
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 1)]
        public const string Cus_Edit = "10009002";
        /// <summary>
        /// Quyền thêm mới Cus
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 1)]
        public const string Cus_Remove = "10009003";
        /// <summary>
        /// Quyền xuất excel danh sách Cus
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 1)]
        public const string Cus_Export = "10009004";
        /// <summary>
        /// Quyền nhập excel danh sách Cus
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 1)]
        public const string Cus_Import = "10009005";
    }
}
