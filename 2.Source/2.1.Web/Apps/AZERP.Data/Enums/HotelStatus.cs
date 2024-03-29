﻿using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum HotelStatus:int
    {
        [Field(Display = "Chưa hoạt động")] None = 0,//Default
        [Field(Display = "Chưa có người thuê")] Active_NonUsed = 1,
        [Field(Display = "Có người thuê")] Active_Used = 2,
        [Field(Display = "Khác")] Other = 3,
    }
}
