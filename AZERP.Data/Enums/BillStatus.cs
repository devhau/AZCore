using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum BillStatus:int
    {
        [Field(Display = "Chưa thanh toán")] None = 0,//Default
        [Field(Display = "Thanh toán thiếu")] Warning = 1,
        [Field(Display = "Đã thanh toán")] Done = 2,
        [Field(Display = "Khác")] Other = 3,
    }
}
