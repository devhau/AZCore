using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    /// <summary>
    /// Tính chất công việc
    /// </summary>
   public enum JobNature
    {
        [Field(Display = "Toàn thời gian")]
        FullTime = 1, 
        [Field(Display = "Bán thời gian")]
        PartTime = 2, 
        [Field(Display = "Làm tại nhà")]
        AtHome = 3,
        [Field(Display = "Chính thức")]
        Official = 4, 
        [Field(Display = "Thời vụ")]
        PartTime2 = 5,
    }
}
