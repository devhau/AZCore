using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Enums
{
    public enum EntiteStatus:Int16
    {
        [Field(FieldDisplay = "Chưa kịch hoạt")]
        NoActive = 0,
        [Field(FieldDisplay="Kịch hoạt")]
        Active=1,
        [Field(FieldDisplay = "Kịch hoạt")]
        Block = 2,
    }
}
