using AZCore.Database.Attributes;

namespace AZERP.Data.Enums
{
    public enum SystemCode:int
    {
        [Field(Display = "Khu nhà trọ",Name ="KNT",Length =5)]
        AreaCode,
        [Field(Display = "Dịch vụ chung", Name = "DVC", Length = 5)]
        CommonServiceCode,
        [Field(Display = "Hóa đơn lưu động", Name = "HDLD", Length = 5)]
        ChangeBillCode,
        [Field(Display = "Hóa đơn cố định", Name = "HDCD", Length = 5)]
        FixedBillCode,
        [Field(Display = "Phòng trọ", Name = "PT", Length = 5)]
        HotelCode,
        [Field(Display = "Dịch vụ của khu vực", Name = "DVKH", Length = 5)]
        AreasService,
        [Field(Display = "Người thuê trọ", Name = "NTT", Length = 5)]
        RenterCode,
        [Field(Display = "Dịch vụ phòng", Name = "DVP", Length = 5)]
        RoomServiceCode,
        [Field(Display = "Loại phòng trọ", Name = "LPT", Length = 5)]
        TypeOfHotelCode,
        [Field(Display ="Ứng viên tuyển dụng", Name = "UVTD", Length = 5)]
        CandidateCode,
        [Field(Display = "Công nhân", Name = "CN", Length = 5)]
        WorkerCode,
        [Field(Display = "Cộng tác viên tuyển dụng", Name = "CTVTD", Length = 5)]
        CollaboratorCode, 
        [Field(Display = "Mã đơn nhập", Name = "DN", Length = 5)]
        ImportCode,
        [Field(Display = "Mã đơn xuất", Name = "DX", Length = 5)]
        ExportCode,
        [Field(Display = "Mã sản phẩm", Name = "SP", Length = 5)]
        ProdcutCode,
        [Field(Display = "Mã khách hàng", Name = "KH", Length = 5)]
        CustomerCode,
        [Field(Display = "Mã nhà cung cấp", Name = "NCC", Length = 5)]
        SupplierCode,
        [Field(Display = "Mã kho", Name = "KHO", Length = 5)]
        StoreCode,
        [Field(Display = "Hợp đồng nhà trọ", Name = "HDNT", Length = 5)]
        ContractCode,
        [Field(Display = "Hóa đơn tổng", Name = "HDT", Length = 5)]
        TotalBillCode,
        [Field(Display = "Thanh toán", Name = "TT", Length = 5)]
        PaymentCode
    }
}
