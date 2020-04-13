using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum Gender : int
    {
        [Field(Display = "Nam")] Male = 1, 
        [Field(Display = "Nữ")] Female = 2,
        [Field(Display = "Chuyển giới")] Transgender = 3,
    }
}
