using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Data.Enums
{
    public enum Month:int
    {
        [Field(Display = "Tháng 1")] January = 1, //January - 31 days 
        [Field(Display = "Tháng 2")] February =2,//February - 28 days in a common year and 29 days in leap years
        [Field(Display = "Tháng 3")] March =3,//March - 31 days
        [Field(Display = "Tháng 4")] April =4,//April - 30 days
        [Field(Display = "Tháng 5")] May =5,//May - 31 days
        [Field(Display = "Tháng 6")] June =6,//June - 30 days
        [Field(Display = "Tháng 7")] July =7,//July - 31 days
        [Field(Display = "Tháng 8")] August =8,//August - 31 days
        [Field(Display = "Tháng 9")] September =9,//September - 30 days
        [Field(Display = "Tháng 10")] October = 10,//October - 31 days
        [Field(Display = "Tháng 11")] November = 11,//November - 30 days
        [Field(Display = "Tháng 12")] December = 12//December - 31 days
    }
}
