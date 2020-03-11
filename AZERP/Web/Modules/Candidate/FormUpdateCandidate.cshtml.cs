using AZ.Web.Entities;
using AZCore.Database.Attr;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZ.Web.Modules.Candidate
{
    public class FormUpdateCandidate : PageModule
    {
        #region Field Data
        /// <summary>
        /// Id
        /// </summary>
        [Field]
        public string Id { get; set; }
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
        #endregion

        CandidateService candidateService;
        public FormUpdateCandidate(IHttpContextAccessor httpContext, CandidateService _candidateService) : base(httpContext)
        {
            this.candidateService = _candidateService;
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
            this.IsTheme = true;
        }

        public  IView Get(object Id)
        {
            return View();
        }
       
    }
}
