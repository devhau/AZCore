using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum DayOfWeek:int
    {  
        //
        // Summary:
        //     Indicates Monday.
        [Field(Display = "Thứ 2")]
        Monday = 1,
        //
        // Summary:
        //     Indicates Tuesday.
        [Field(Display = "Thứ 3")]
        Tuesday = 2,
        //
        // Summary:
        //     Indicates Wednesday.
        [Field(Display = "Thứ 4")]
        Wednesday = 3,
        //
        // Summary:
        //     Indicates Thursday.
        [Field(Display = "Thứ 5")]
        Thursday = 4,
        //
        // Summary:
        //     Indicates Friday.
        [Field(Display = "Thứ 6")]
        Friday = 5,
        //
        // Summary:
        //     Indicates Saturday.
        [Field(Display = "Thứ 7")]
        Saturday = 6, 
        //
        // Summary:
        //     Indicates Sunday.
        [Field(Display = "Chủ nhật")]
        Sunday = 0,
    }
}
