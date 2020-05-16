using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý Area
       /// </summary>
        [Field(Display = "Quản lý Area", OrderIndex = 5)]
        public const string Area = "10005";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 5)]
        public const string Area_Add = "10005001";
        /// <summary>
        /// Quyền chỉnh sửa Area
        /// </summary>
        /// 

        [Field(Display = "Sửa", OrderIndex = 5)]
        public const string Area_Edit = "10005002";
        /// <summary>
        /// Quyền thêm mới Area
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 5)]
        public const string Area_Remove = "10005003";
        /// <summary>
        /// Quyền xuất excel danh sách Area
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 5)]
        public const string Area_Export = "10005004";
        /// <summary>
        /// Quyền nhập excel danh sách Area
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 5)]
        public const string Area_Import = "10005005";
    }
}
