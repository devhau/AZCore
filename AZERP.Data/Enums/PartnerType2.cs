using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    public enum PartnerType2:int
    {
        [Field(Display = "Khách hàng")] Customer = 1,
        [Field(Display = "Nhà cung cấp")] Supplier = 2
    }
}
