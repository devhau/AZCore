using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        /// <summary>
        /// Quyền quản lý Sản phẩm
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index, Display = "Quản lý sản phẩm", OrderIndex = 2)]
        public const string Product = "42626180-2126-4837-b55c-32a0c16dbdf7";
        /// <summary>
        /// Quyền thêm mới Product
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index,Display = "Thêm mới", OrderIndex = 2)]
        public const string Product_Add = "ae913903-a08b-4cd3-8f50-bc8cb6afb19e";
        /// <summary>
        /// Quyền chỉnh sửa Product
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index,Display = "Sửa", OrderIndex = 2)]
        public const string Product_Edit = "b116210b-f61c-4712-93eb-084eb6572d87";
        /// <summary>
        /// Quyền thêm mới Product
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index,Display = "Xóa", OrderIndex = 2)]
        public const string Product_Remove = "9a5213e2-2e03-4821-bb64-c34d73ff16a7";
        /// <summary>
        /// Quyền xuất excel danh sách Product
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index,Display = "Xuất excel", OrderIndex = 2)]
        public const string Product_Export = "bff5f581-f5e4-4421-8602-9d6961301652";
        /// <summary>
        /// Quyền nhập excel danh sách Product
        /// </summary>
        [Field(GroupName = Group_Sales, GroupIndex = Group_Sales_Index,Display = "Nhập excel", OrderIndex = 2)]
        public const string Product_Import = "b9c84699-1e6b-4597-bb00-7f4851fa906a";
    }
}
