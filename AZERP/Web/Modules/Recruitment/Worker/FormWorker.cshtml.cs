using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Recruitment.Worker
{
    [TableColumn(Title = "Họ Tên", FieldName = "FullName", Width = 130)]
    [TableColumn(Title = "Giới tính", FieldName = "Gender", Width = 80,DataType =typeof(Gender))]
    [TableColumn(Title = "CMT", FieldName = "CMD", Width = 130)]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = 100)]
    [TableColumn(Title = "Ngày sinh", FieldName = "BirthDay", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address", Width = 150)]
    [TableColumn(Title = "Ở hiện tại", FieldName = "AddressCurrent", Width = 150)]
    [TableColumn(Title = "Làm khu vực", FieldName = "TargetToAddress", Width = 150, DataType = typeof(AddressWorker))]
    [TableColumn(Title = "Công ty", FieldName = "CompanyId", Width = 150, DataType = typeof(CompanyWorkerService))]
    [TableColumn(Title = "Trạng thái", FieldName = "WorkerStatus", Width = 150, DataType = typeof(WorkerStatus))]
    [TableColumn(Title = "Ngày đi làm", FieldName = "StartWork", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Ngày nghỉ việc", FieldName = "LastWork", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Chấm công", LinkFormat = "/cham-cong-cong-nhan.az?CompanyId={CompanyId}&WorkerId={Id}" ,ReLoadAfterPopupClose =false ,Popup =PopupSize.FullScreen, Text ="Chấm công", Icon="fas fa-check-double", Width = 70,Display = DisplayColumn.Icon)]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    public class FormWorker : ManageModule<WorkerService, WorkerModel, FormUpdateWorker>
    {
        #region -- Field Search --
        /// <summary>
        /// Họ Tên
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string FullName { get; set; }
        /// <summary>
        /// <summary>
        /// Ngày sinh
        /// </summary>
        [QuerySearch]
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [QuerySearch]
        public Gender? Gender { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ của ứng viên
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Address { get; set; }
        /// <summary>
        /// Nơi ở hiện tại
        /// </summary>
        [QuerySearch]
        public string AddressCurrent { get; set; }
        /// <summary>
        /// Đường dẫn Facebook
        /// </summary>
        [QuerySearch]
        public string LinkFacebook { get; set; }
        /// <summary>
        /// Nguồn thông tin này ở đâu.
        /// Trang: Kho Việc Làm Bắc Ninh
        /// </summary>
        [QuerySearch]
        public string Source { get; set; }
        /// <summary>
        /// Nguyện Vọng của ứng viên
        /// </summary>
        [QuerySearch]
        public string AspirationsOfWorkers { get; set; }
        /// <summary>
        /// Lựa chọn vị trí công việc ở địa chỉ nào.
        /// Mục đích để Thông kê
        /// Ví dụ:
        /// 1-Quế Võ 1,Bắc Ninh
        /// 2-Quế Võ 2,Bắc Ninh
        /// 3-Yên Phong,Bắc Ninh
        /// 4-Bắc Giang
        /// </summary>
        [QuerySearch]
        public AddressWorker? TargetToAddress { get; set; }
        /// <summary>
        /// Loại của ứng viên.
        /// Chính Thức 
        /// Thời vụ.
        /// </summary>
        [QuerySearch]
        public TypeOfCandidate? TypeOfWorker { get; set; }
        /// <summary>
        /// Trạng thái công nhân
        /// </summary>
        [QuerySearch]
        public WorkerStatus? WorkerStatus { get; set; }
        /// <summary>
        /// Công ty
        /// </summary>
        [QuerySearch]
        public long? CompanyId { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [QuerySearch]
        public DateTime? CreateAt { get; set; }
        #endregion

        public FormWorker(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý công nhân";
        }
    }
}
