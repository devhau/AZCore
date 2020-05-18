using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum TypeOfContractStatus : int
    {
        [Field(Display = "Chưa hoạt động")] chuaHD = 0,//Default
        [Field(Display = "Đang hoạt động")] dangHD = 1,
        [Field(Display = "Kết thúc")] ketthuc = 2,
    }
}
