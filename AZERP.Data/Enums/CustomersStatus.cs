using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum CustomersStatus:int
    {
        [Field(Display = "Đang giao dịch")] active = 0,
        [Field(Display = "Ngừng giao dịch")] deactive = 1,
    }
}
