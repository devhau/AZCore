using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum PurchaseOrderImport:int
    {
        [Field(Display = "Chờ nhập hàng")] WaitingImport = 1,
        [Field(Display = "Đã nhập hàng")] Import = 2,
        [Field(Display = "Chờ xuất hàng")] WaitingExport = 3,
        [Field(Display = "Đã xuất hàng")] Export = 4
    }
}
