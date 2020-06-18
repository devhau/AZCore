using AZCore.Database;
using AZCore.Database.Attributes;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// Thông tin tuyển dụng
    /// </summary>
    [TableInfo(TableName = "az_job_info")]
    public class JobInfo : EntityModel<JobInfo, long>
    {
        /// <summary>
        /// Tiêu đề của bài đăng
        /// </summary>
        [Field(Length = 500)]
        public string Title { get; set; }
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
    }
}
