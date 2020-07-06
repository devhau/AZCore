using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class JobInfoService : EntityService<JobInfoService, JobInfoModel>, IAZTransient
    {
        public JobInfoService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin tuyển dụng
    /// </summary>
    [TableInfo(TableName = "az_recruitment_job_info")]
    public class JobInfoModel : EntityModel<JobInfoModel, long>
    {
        /// <summary>
        /// Tiêu đề của bài đăng
        /// </summary>
        [Field(Length = 500)]
        public string Title { get; set; }
        [Field(Length = 1000)]
        public string Address { get; set; }
        /// <summary>
        /// Nội dung của bài đăng
        /// </summary>
        [Field]
        public string Content { get; set; }
        /// <summary>
        /// Từ khóa tìm kiếm tốt hơn
        /// </summary>
        [Field(Length = 500)]
        public string Keyword { get; set; }
        /// <summary>
        /// Mô tả để hỗ trợ seo tốt hơn
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
        /// <summary>
        /// Tên lĩnh vực
        /// Cho phép tự cấu hình
        /// </summary>
        [Field(Length = 500)]
        public string ProfessionName { get; set; }
        /// <summary>
        /// Id của lĩnh vực
        /// </summary>
        [Field]
        public long? ProfessionId { get; set; }
        /// <summary>
        /// Công ty
        /// </summary>
        [Field]
        public long CompanyId { get; set; }
        /// <summary>
        /// Lương từ
        /// </summary>
        [Field]
        public long SalaryFrom { get; set; }
        /// <summary>
        /// Lương đến
        /// </summary>
        [Field]
        public long SalaryTo { get; set; }
        /// <summary>
        /// Áp dụng từ ngày
        /// </summary>
        [Field]
        public DateTime JobFrom { get; set; }
        /// <summary>
        /// Áp dụng đến ngày
        /// </summary>
        [Field]
        public DateTime JobTo { get; set; }
        /// <summary>
        /// Loại hình lao động
        /// </summary>
        [Field]
        public JobNature JobType { get; set; }
        /// <summary>
        /// Tuổi từ
        /// </summary>
        [Field]
        public long OldFrom { get; set; }
        /// <summary>
        /// Tuổi đến
        /// </summary>
        [Field]
        public long OldTo { get; set; }
        public JobGender Gender { get; set; }
    }
}
