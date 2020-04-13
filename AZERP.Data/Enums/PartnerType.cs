using AZCore.Database.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZERP.Data.Enums
{
    /// <summary>
    /// Kiểu đối tác
    /// </summary>
    public enum PartnerType:int
    {
        [Field(Display ="Chưa xác định")]
        None=0,
        [Field(Display = "Cá nhân")]
        Individual =1,
        [Field(Display = "Công ty")]
        Company =2,
        [Field(Display = "Tổ chức")]
        Organization =3
    }
}
