using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class WorkerService : EntityService<WorkerService, WorkerModel>, IAZTransient
    {
        public WorkerService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin công nhân
    /// </summary>

    [TableInfo(TableName = "az_worker")]
    public class WorkerModel : EntityModel<WorkerModel, long>
    {
        /// <summary>
        /// Họ Tên
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string FullName { get; set; }
        /// <summary>
        /// Chứ minh thư
        /// </summary>
        [Field(Length = 20)]
        public string CMD { get; set; }
        /// <summary>
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [Field]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [Field]
        public EnumGender? Gender { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 5000)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ của ứng viên
        /// </summary>
        [Field(Length = 1000)]
        public string Address { get; set; }
        /// <summary>
        /// Nơi ở hiện tại
        /// </summary>
        [Field(Length = 1000)]
        public string AddressCurrent { get; set; }
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
        /// Lựa chọn vị trí công việc ở địa chỉ nào.
        /// Mục đích để Thông kê
        /// Ví dụ:
        /// 1-Quế Võ 1,Bắc Ninh
        /// 2-Quế Võ 2,Bắc Ninh
        /// 3-Yên Phong,Bắc Ninh
        /// 4-Bắc Giang
        /// </summary>
        [Field]
        public EnumAddressWorker? TargetToAddress { get; set; }
        /// <summary>
        /// Loại của ứng viên.
        /// Chính Thức 
        /// Thời vụ.
        /// </summary>
        [Field]
        public EnumTypeOfCandidate? TypeOfCandidate { get; set; }
        /// <summary>
        /// Tình trạng công nhân
        /// </summary>
        [Field]
        public EnumWorkerStatus? WorkerStatus { get; set; }
        /// <summary>
        /// Ngày bắt đầu công việc
        /// </summary>
        [Field]
        public DateTime? StartWork { get; set; }
        /// <summary>
        /// Ngày kết thúc việc
        /// </summary>
        public DateTime? LastWork { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
        /// <summary>
        /// Làm việc ở công ty
        /// </summary>
        [Field]
        public long? CompanyId { get; set; }
        /// <summary>
        /// Thông tin ứng viên
        /// </summary>
        [Field] 
        public long? CandidateId { get; set; }
    }
}
