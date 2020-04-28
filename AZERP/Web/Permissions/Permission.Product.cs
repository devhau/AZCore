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
        [Field(Display = "Quản lý sản phẩm", OrderIndex = 2)]
        public const string Product = "10004";
        /// <summary>
        /// Quyền thêm mới Product
        /// </summary>
        [Field(Display = "Thêm mới", OrderIndex = 2)]
        public const string Product_Add = "10004001";
        /// <summary>
        /// Quyền chỉnh sửa Product
        /// </summary>
        [Field(Display = "Sửa", OrderIndex = 2)]
        public const string Product_Edit = "10004002";
        /// <summary>
        /// Quyền thêm mới Product
        /// </summary>
        [Field(Display = "Xóa", OrderIndex = 2)]
        public const string Product_Remove = "10004003";
        /// <summary>
        /// Quyền xuất excel danh sách Product
        /// </summary>
        [Field(Display = "Xuất excel", OrderIndex = 2)]
        public const string Product_Export = "10004004";
        /// <summary>
        /// Quyền nhập excel danh sách Product
        /// </summary>
        [Field(Display = "Nhập excel", OrderIndex = 2)]
        public const string Product_Import = "10004005";
    }
}
