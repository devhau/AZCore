using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum EnumGender : int
    {
        [Field(Display = "Giới tính")] None=0,//Default
        [Field(Display = "Nam")] Male = 1, 
        [Field(Display = "Nữ")] Female = 2,
        [Field(Display = "Chuyển giới")] Transgender = 3,
    }
}
