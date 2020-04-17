using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum PurchaseOrderStatus:int
    {
        [Field(Display = "Đang thực hiện")] Waiting = 0,
        [Field(Display = "Kết thúc")] Close = 1,
        [Field(Display = "Hoàn thành")] Complete = 2,
    }
}
