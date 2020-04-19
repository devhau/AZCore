using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Permissions
{
    public partial class Permission
    {
        [Field(Display = "Quản lý sản phẩm", OrderIndex = 3)]
        public const string Product = "10004";
        [Field(Display = "Thêm mới", OrderIndex = 3)]
        public const string Product_Add = "10004001";
    }
}
