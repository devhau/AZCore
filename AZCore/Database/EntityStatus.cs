using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EntityStatus:int
    {
        [Field(Display = "Chưa kích hoạt")]
        NoActive = 0,
        [Field(Display = "Kích hoạt")]
        Active=1,
        [Field(Display = "Bị khóa")]
        Block = 2,
    }
}
