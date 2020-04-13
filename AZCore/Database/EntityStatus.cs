using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EntityStatus:int
    {
        [Field(Display = "Chưa kịch hoạt")]
        NoActive = 0,
        [Field(Display = "Kịch hoạt")]
        Active=1,
        [Field(Display = "Bị khóa")]
        Block = 2,
    }
}
