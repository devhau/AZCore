using AZCore.Database;
using AZCore.Database.Attributes;
using AZERP.Data.Enums;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// thông tin của công nhân
    /// </summary>
    [TableInfo(TableName = "az_recruitment_worker_profile")]
    public class WorkerProfile : EntityTenantModel<WorkerProfile, long>
    {
        /// <summary>
        /// Id của Tài khoản
        /// cho phép link tới tài khoản để chấm công bằng app JobF.
        /// </summary>
        [Field]
        public long? UserId { get; set; }
        /// <summary>
        /// Kiểu của profile
        /// </summary>
        [Field] 
        public JobProfileType ProfileType { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [Field]
        public Gender GenderType { get; set; }
        /// <summary>
        /// Họ tên ứng viên
        /// </summary>
        [Field(Length = 256)]
        public string FullName { get; set; }
        /// <summary>
        /// Địa chỉ thường trú.
        /// </summary>
        [Field(Length = 500)]
        public string PermanentAddress { get; set; }
        /// <summary>
        /// Địa chỉ hiện tại
        /// </summary>
        [Field(Length = 500)]
        public string CurrentAddress {get;set;}
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 20)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại khoác
        /// </summary>
        [Field(Length = 20)]
        public string PhoneNumber2 { get; set; }
        /// <summary>
        /// Facebook
        /// </summary>
        [Field(Length = 500)]
        public string LinkFacebook { get; set; }
        /// <summary>
        /// chứng minh mặt trước.
        /// </summary>
        [Field(Length = 500)]
        public string IDCardBefore { get; set; }
        /// <summary>
        /// chứng minh mặt sau.
        /// </summary>
        [Field(Length = 500)]
        public string IDCardAfter { get; set; }
        /// <summary>
        /// Đường đẫn FileCV
        /// </summary>
        [Field(Length = 500)] 
        public string FileCV { get; set; }

    }
}
