using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using System;
using System.Data;

namespace AZ.Web.Entities
{
    public class CandidateService : EntityService<CandidateService, CandidateModel>, IAZTransient
    {
        public CandidateService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của ứng viên
    /// </summary>

    [TableInfo(TableName = "az_candidate")]
    public class CandidateModel : EntityModel<CandidateModel, long>
    {
        /// <summary>
        /// Họ Tên
        /// </summary>
        [Field(Length = 500)]
        public string Fullname { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 5000)] 
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        [Field(Length = 500)]
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ của ứng viên
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Đường dẫn Facebook
        /// </summary>
        [Field(Length = 5000)]
        public string LinkFacebook { get; set; }
        /// <summary>
        /// Nguồn thông tin này ở đâu.
        /// Trang: Kho Việc Làm Bắc Ninh
        /// </summary>
        [Field(Length = 5000)]
        public string Source { get; set; }
        /// <summary>
        /// Nguyện Vọng của ứng viên
        /// </summary>
        [Field(Length = 5000)]
        public string AspirationsOfCandidates { get; set; }
        /// <summary>
        /// Lựa chọn vị trí công việc ở địa chỉ nào.
        /// Mục đích để Thông kê
        /// Ví dụ:
        /// 1-Quế Võ 1,Bắc Ninh
        /// 2-Quế Võ 2,Bắc Ninh
        /// 3-Yên Phong,Bắc Ninh
        /// 4-Bắc Giang
        /// </summary>
        [Field]
        public int TargetToAddress { get; set; }
        /// <summary>
        /// Loại của ứng viên.
        /// Chính Thức 
        /// Thời vụ.
        /// </summary>
        [Field]
        public int TypeOfCandidate { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        [Field]
        public int Status { get; set; }
        /// <summary>
        /// Thời gian gọi gần đây nhất
        /// </summary>
        [Field]
        public DateTime? CallAt { get; set; }
        /// <summary>
        /// Hẹn thời gian đến công ty
        /// </summary>
        [Field]
        public DateTime? GoCompanyAt { get; set; }
        /// <summary>
        /// Hoàn thành lúc
        /// </summary>
        [Field]
        public DateTime? CompleteAt { get; set; }
        /// <summary>
        /// Thời gian bắt đầu công việc
        /// </summary>
        [Field]
        public DateTime? StartWork { get; set; }
        /// <summary>
        /// Tạo bởi ai đó
        /// </summary>
        [Field]
        public long CreateBy { get; set; }
        /// <summary>
        /// Cập nhật ai đó
        /// </summary>
        [Field]
        public long? UpdateBy { get; set; }
        /// <summary>
        /// Dán cho ai đó
        /// </summary>
        [Field]
        public long? AssignTo { get; set; }
    }
}
