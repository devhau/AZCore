using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
   public enum JobGender : int
    {
        [Field(Display = "Tuyển Nam")] Male = 1,
        [Field(Display = "Tuyển Nữ")] Female = 2,
        [Field(Display = "Tuyển Cặp Nam/Nữ")] MaleFemale = 3,
        [Field(Display = "Tuyển Nam/Nữ")] All = 4,
    }
}
