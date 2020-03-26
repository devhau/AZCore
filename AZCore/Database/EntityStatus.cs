using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EntityStatus:Int16
    {
        [Field(FieldDisplay = "Chưa kịch hoạt")]
        NoActive = 0,
        [Field(FieldDisplay = "Kịch hoạt")]
        Active=1,
        [Field(FieldDisplay = "Bị khóa")]
        Block = 2,
    }
}
