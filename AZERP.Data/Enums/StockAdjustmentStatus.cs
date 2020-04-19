using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum StockAdjustmentStatus:int
    {
        [Field(Display = "Đang kiểm hàng")] Pending = 0,
        [Field(Display = "Đã kiểm hàng")] Complete = 1,
    }
}
