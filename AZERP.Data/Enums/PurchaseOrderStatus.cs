using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum OrderStatus:int
    {
        [Field(Display = "Đang thực hiện")] Waiting = 1,
        [Field(Display = "Kết thúc")] Close = 2,
        [Field(Display = "Hoàn thành")] Complete = 3,
    }
}
