using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    //day shift; night shift
    public enum EnumWorkShift:int
    {
        [Field(Display = "Ca ngày")] DayShift = 1,
        [Field(Display = "Ca đêm")]  NightShift = 2,
        [Field(Display = "Ca 1")]    OneShift = 3,
        [Field(Display = "Ca 2")]    TwoShift = 4,
        [Field(Display = "Ca 3")]    ThreeShift = 5
    }
}
