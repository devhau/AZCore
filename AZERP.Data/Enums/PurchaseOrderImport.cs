using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum PurchaseOrderImport:int
    {
        [Field(Display = "Chờ nhập hàng")] WaitingImport = 0,
        [Field(Display = "Đã nhập hàng")] Import = 1,
        [Field(Display = "Chờ xuất hàng")] WaitingExport = 2,
        [Field(Display = "Đã xuất hàng")] Export = 3
    }
}
