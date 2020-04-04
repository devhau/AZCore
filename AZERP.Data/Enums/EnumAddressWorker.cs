using AZCore.Database.Attr;

namespace AZERP.Data.Enums
{
    public enum EnumAddressWorker:int
    {
        [Field(Display = "Quế Võ 1, Bắc Ninh")] QueVo1BacNinh = 1,
        [Field(Display = "Quế Võ 2, Bắc Ninh")] QueVo2BacNinh = 2,
        [Field(Display = "Quế Võ 3, Bắc Ninh")] QueVo3BacNinh = 3,
        [Field(Display = "Yên Phong, Bắc Ninh")] YenPhongBacNinh = 4,
        [Field(Display = "Vân Trung, Bắc Giang")] VanTrungBacGiang = 5,
    }
}
