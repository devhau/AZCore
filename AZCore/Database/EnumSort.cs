using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EnumSort
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "Tăng dần")]
        ASC,
        [Field(Display = "Giảm dần")]
        DESC
    }
}
