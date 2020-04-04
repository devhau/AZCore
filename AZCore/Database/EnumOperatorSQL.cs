using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public enum EnumOperatorSQL
    {
        [Field(Display ="")]
        None, 
        [Field(Display = "LIKE %%")]
        LIKE,
        [Field(Display = "IN (1,2,3)")]
        IN,
        [Field(Display = "=")]
        EQUAL
    }
}
