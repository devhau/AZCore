using AZCore.Database;
using AZCore.Database.Attributes;
using System;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// Thông tin các công ty cần sử dụng lao động
    /// //Phần này sẽ dùng chung cho các đối tác tuyển dụng
    /// </summary>
    [TableInfo(TableName = "az_job_company")]
    public class JobCompany : EntityModel<JobCompany, long>
    {
        /// <summary>
        /// Tên công ty
        /// vd: Samsung Bắc Ninh
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// đường dẫn tới công ty.
        /// vd: jobf.vn/cong-ty/samsung-bac-ninh.az
        /// </summary>
        [Field(Length = 500)]
        public string Slug { get; set; }
        /// <summary>
        /// Thời gian thay đổi đường dẫn gần đây nhất.
        /// vd: 20:25:00 15/06/2016
        /// </summary>
        [Field]
        public DateTime UpdateSlug { get; set; }
        /// <summary>
        /// Mã code
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Địa chỉ:
        /// vd: Yên Phong - Bắc Ninh
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Bài viết giới thiệu
        /// </summary>
        [Field]
        public string PostInfo { get; set; }
        /// <summary>
        /// Từ khóa giúp SEO tốt hơn.
        /// vd: Công ty samsung,samsung bắc ninh,.....
        /// </summary>
        [Field(Length = 1000)]
        public string Keyword { get; set; }
        /// <summary>
        /// Giới thiệu qua công ty.
        /// vd:....
        /// </summary>
        [Field(Length = 1000)]
        public string ShortInfo { get; set; }
        /// <summary>
        /// Địa chỉ page facebook: 
        /// vd: facebook.com//jobf.samsung.bacninh
        /// </summary>
        [Field(Length = 500)]
        public string PageCompany { get; set; }
        /// <summary>
        /// Địa chỉ youtube
        /// vd: youtube.com//jobf.samsung.bacninh
        /// </summary>
        [Field(Length = 500)]
        public string YoutubeCompany { get; set; }
        /// <summary>
        /// Địa chỉ website
        /// vd: samsung-bacninh.jobf.vn
        /// </summary>
        [Field(Length = 500)]
        public string WebsiteCompany { get; set; }
        /// <summary>
        /// Là công ty cho phép đối tác khác tuyển dụng cho công ty
        /// </summary>
        [Field]
        public bool IsCommon {get;set; }
        /// <summary>
        /// Là các đơn vị tuyển dụng.
        /// ví dụ: JobF là hệ thống tuyển dụng cho các công ty như samsung
        /// </summary>
        [Field]
        public bool IsPartner { get; set; }
        /// <summary>
        /// Cho phép tìm kiếm được ngoài trang chủ.
        /// </summary>
        [Field]
        public bool IsPublic { get; set; }
    }
}
