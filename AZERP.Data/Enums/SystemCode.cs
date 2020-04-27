using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
        [Field(Display ="Tao thử mày thôi")]
        Demo,
        [Field(Display = "Khu nhà trọ")]
        AreaCode,
        [Field(Display = "Dịch vụ chung")]
        CommonServiceCode,
        [Field(Display = "Hóa đơn lưu động")]
        ChangeBillCode,
        [Field(Display = "Hóa đơn cố định")]
        FixedBillCode,
        [Field(Display = "Phòng trọ")]
        HotelCode,
        [Field(Display = "Dịch vụ của khu vực")]
        RegionalService,
        [Field(Display = "Người thuê trọ")]
        RenterCode,
        [Field(Display = "Dịch vụ phòng")]
        RoomServiceCode,
        [Field(Display = "Loại phòng trọ")]
        TypeOfHotelCode
    }
}
