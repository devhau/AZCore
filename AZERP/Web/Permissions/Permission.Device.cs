using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý thiết bị
       /// </summary>
        [Field(Display = "Quản lý thiết bị", OrderIndex = 5)]
        public const string Device = "10001";
        /// <summary>
        /// Quyền thêm mới thiết bị
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 5)]
        public const string Device_Add = "10002001";
        /// <summary>
        /// Quyền chỉnh sửa thiết bị
        /// </summary>
        /// 

        [Field(Display = "Sửa", OrderIndex = 5)]
        public const string Device_Edit = "10001002";
        /// <summary>
        /// Quyền thêm mới thiết bị
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 5)]
        public const string Device_Remove = "10001003";
        /// <summary>
        /// Quyền xuất excel danh sách thiết bị
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 5)]
        public const string Device_Export = "10001004";
        /// <summary>
        /// Quyền nhập excel danh sách thiết bị
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 5)]
        public const string Device_Import = "10001005";
    }
}
