using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.Enums
{
    public enum SortType
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "Tăng dần")]
        ASC,
        [Field(Display = "Giảm dần")]
        DESC
    }
}
