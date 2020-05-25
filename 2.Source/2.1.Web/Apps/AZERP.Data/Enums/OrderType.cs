using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum OrderType:int
    {
        [Field] In = 1,
        [Field] Out = 2,
    }
}
