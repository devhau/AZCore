using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum ProductType : int
    {
        [Field(Display = "Cho phép bán")] Sellable = 1, 
        [Field(Display = "Không cho phép bán")] NotSellable = 2,
    }
}
