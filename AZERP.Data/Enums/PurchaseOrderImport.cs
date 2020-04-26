using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum PurchaseOrderImport:int
    {
        [Field(Display = "Chờ nhập hàng")] Waiting = 0,
        [Field(Display = "Đã nhập hàng")] Import = 1,
        [Field(Display = "Không nhập hàng")] NotImport = 2
    }
}
