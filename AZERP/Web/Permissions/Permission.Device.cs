using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý thiết bị
       /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Quản lý thiết bị", OrderIndex = 5)]
        public const string Device = "1c77aa96-b1d0-41e0-92e7-acd17cb92ba7";
        /// <summary>
        /// Quyền thêm mới thiết bị
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Thêm mới", OrderIndex = 5)]
        public const string Device_Add = "43bef1e7-f23f-4f8d-9dd9-ad86f51e2c53";
        /// <summary>
        /// Quyền chỉnh sửa thiết bị
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Sửa", OrderIndex = 5)]
        public const string Device_Edit = "a8e42be6-2ab1-4ed0-8f1a-2776963fd92f";
        /// <summary>
        /// Quyền thêm mới thiết bị
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xóa", OrderIndex = 5)]
        public const string Device_Remove = "aaf4952b-c564-4d38-8b1f-cb7deeb8f703";
        /// <summary>
        /// Quyền xuất excel danh sách thiết bị
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xuất excel", OrderIndex = 5)]
        public const string Device_Export = "070406fe-c1fc-46a7-aec5-3b211562f1d4";
        /// <summary>
        /// Quyền nhập excel danh sách thiết bị
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Nhập excel", OrderIndex = 5)]
        public const string Device_Import = "a6fa0661-6cf6-42ee-901f-8b68023492e1";
    }
}
