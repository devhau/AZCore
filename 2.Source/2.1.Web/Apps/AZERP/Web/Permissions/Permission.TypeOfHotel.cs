using AZCore.Database.Attributes;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {  /// <summary>
       /// Quyền quản lý TypeOfHotel
       /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Quản lý TypeOfHotel", OrderIndex = 6)]
        public const string TypeOfHotel = "054b632b-1859-4709-9b0d-aad2ccc2cf08";
        /// <summary>
        /// Quyền thêm mới TypeOfHotel
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Thêm mới", OrderIndex = 6)]
        public const string TypeOfHotel_Add = "e0b5edc3-7687-480b-a7f2-c79cd47085ab";
        /// <summary>
        /// Quyền chỉnh sửa TypeOfHotel
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Sửa", OrderIndex = 6)]
        public const string TypeOfHotel_Edit = "62a2f1e7-8152-45e5-b84f-257d6115cdd2";
        /// <summary>
        /// Quyền thêm mới TypeOfHotel
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xóa", OrderIndex = 6)]
        public const string TypeOfHotel_Remove = "1ac28b5c-8642-4147-bab7-2cfd663e725f";
        /// <summary>
        /// Quyền xuất excel danh sách TypeOfHotel
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Xuất excel", OrderIndex = 6)]
        public const string TypeOfHotel_Export = "eea1e4e6-64ab-426d-af2a-fc345c00285a";
        /// <summary>
        /// Quyền nhập excel danh sách TypeOfHotel
        /// </summary>
        [Field(GroupName = Group_Hotel, GroupIndex = Group_Hotel_Index,Display = "Nhập excel", OrderIndex = 6)]
        public const string TypeOfHotel_Import = "469a119c-1741-4016-8fcd-a399c9fe6c3f";
    }
}
