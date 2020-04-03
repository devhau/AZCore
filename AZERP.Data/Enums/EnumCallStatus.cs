using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum EnumCallStatus:int
    {
        [Field(Display = "Chưa gọi")] None = 0,//Default
        [Field(Display = "Hẹn đi làm")] HenDiLam = 1,//Default
        [Field(Display = "Không nghe máy")] KhongNgheMay = 2,//
        [Field(Display = "Không liên lạc")] KhongLienLac = 3,//Default
        [Field(Display = "Hẹn lại")] HenLai = 4,//Default
        [Field(Display = "Không đi làm")] KhongDiLam = 5,//Default
        [Field(Display = "Chưa đi làm")] ChuaDiLam = 6,//Default
    }
}
