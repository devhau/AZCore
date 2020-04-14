using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum CheckinCheckoutEditor:int
    {
        [Field(Display = "Chỉ hôm nay")]
        OnlyToday =0,
        [Field(Display = "Từ 7 ngày trước")]
        OnlyWeek =1,
        [Field(Display ="Tất cả")]
        All = 99,
    }
}
