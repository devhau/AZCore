using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum WorkerStatus:int
    {
        [Field(Display = "Chờ việc")] Pedding = 0,
        [Field(Display = "Đang đi làm")] Working = 1,
        [Field(Display = "Công ty đang hết việc")] Free = 2,
        [Field(Display = "Nghỉ muốn tìm việc khác")] FindWorkOther = 3,
        [Field(Display = "Nghỉ việc")] Leave = 4,
    }
}
