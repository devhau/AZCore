﻿using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum OrderPayment:int
    {
        [Field(Display = "Chưa thanh toán")] Unpaid = 1,
        [Field(Display = "Đã thanh toán")] Paid = 2,
        [Field(Display = "Hoàn tiền toàn bộ")] Refund = 3
    }
}
