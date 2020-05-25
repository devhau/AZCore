using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum TypeOfContractStatus : int
    {
        [Field(Display = "Đang hoạt động")] dangHD = 0,
        [Field(Display = "Kết thúc")] ketthuc = 1,
    }
}
