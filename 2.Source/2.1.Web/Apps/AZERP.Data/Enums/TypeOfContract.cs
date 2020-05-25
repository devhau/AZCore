using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum TypeOfContract : int
    {
        [Field(Display = "Hợp đồng 1 tháng")] Contract1 = 1,//Default
        [Field(Display = "Hợp đồng 3 tháng")] Contract3 = 3,
        [Field(Display = "Hợp đồng 6 tháng")] Contract6 = 6,
        [Field(Display = "Hợp đồng 12 tháng")] Contract12 = 12,
    }
}
