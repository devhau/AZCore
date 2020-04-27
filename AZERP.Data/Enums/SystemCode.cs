using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
        [Field(Display = "Khu nhà trọ")]
        AreaCode,
        [Field(Display = "Mã đơn nhập")]
        ImportCode,
        [Field(Display = "Mã đơn xuất")]
        ExportCode,
        [Field(Display = "Mã sản phẩm")]
        ProdcutCode,
    }
}
