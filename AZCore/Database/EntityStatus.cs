using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EntityStatus:int
    {
        [Field(Display = "Đang hoạt động")]
        NoActive = 0,
        [Field(Display = "Chưa kích hoạt")]
        Active=1,
        [Field(Display = "Bị khóa")]
        Block = 2,
    }
}
