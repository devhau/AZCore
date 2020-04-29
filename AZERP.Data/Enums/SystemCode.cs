using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
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
        TypeOfHotelCode,
        [Field(Display ="Ứng viên tuyển dụng")]
        CandidateCode,
        [Field(Display = "Công nhân")]
        WorkerCode,
        [Field(Display = "Cộng tác viên tuyển dụng")]
        CollaboratorCode, 
        [Field(Display = "Mã đơn nhập")]
        ImportCode,
        [Field(Display = "Mã đơn xuất")]
        ExportCode,
        [Field(Display = "Mã sản phẩm")]
        ProdcutCode,
        [Field(Display = "Mã khách hàng")]
        CustomerCode,
        [Field(Display = "Mã nhà cung cấp")]
        SupplierCode,
        [Field(Display = "Mã kho")]
        StoreCode
    }
}
