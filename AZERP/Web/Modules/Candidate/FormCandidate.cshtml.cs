﻿using AZCore.Database.Attr;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Candidate
{
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt", Width = 100,FormatString ="{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Họ Tên", FieldName = "FullName", Width = 130)]
    [TableColumn(Title = "Giới tính", FieldName = "Gender", Width = 80,DataType =typeof(EnumGender))]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = 100)]
    [TableColumn(Title = "Ngày sinh", FieldName = "BirthDay", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address", Width = 150)]
    [TableColumn(Title = "Ở hiện tại", FieldName = "AddressCurrent", Width = 150)]
    [TableColumn(Title = "Làm khu vực", FieldName = "TargetToAddress", Width = 150, DataType = typeof(EnumAddressWorker))]
    [TableColumn(Title = "Trạng thái gọi", FieldName = "CallStatus", Width = 150, DataType = typeof(EnumCallStatus))]
    [TableColumn(Title = "Hẹn đi làm", FieldName = "StartWork", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Hẹn đến văn phòng", FieldName = "GoCompanyAt", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Hẹn gọi lại", FieldName = "CallBack", Width = 100, FormatString = "{0:dd/MM/yyyy}")]
    public class FormCandidate : ManageModule<CandidateService, CandidateModel, FormUpdateCandidate>
    {
        #region -- Field Search --
        /// <summary>
        /// Họ Tên
        /// </summary>
        [Field]
        public string FullName { get; set; }
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
        [Field]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ của ứng viên
        /// </summary>
        [Field]
        public string Address { get; set; }
        /// <summary>
        /// Nơi ở hiện tại
        /// </summary>
        [Field]
        public string AddressCurrent { get; set; }
        /// <summary>
        /// Đường dẫn Facebook
        /// </summary>
        [Field]
        public string LinkFacebook { get; set; }
        /// <summary>
        /// Nguồn thông tin này ở đâu.
        /// Trang: Kho Việc Làm Bắc Ninh
        /// </summary>
        [Field]
        public string Source { get; set; }
        /// <summary>
        /// Nguyện Vọng của ứng viên
        /// </summary>
        [Field]
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
        public EnumAddressWorker? TargetToAddress { get; set; }
        /// <summary>
        /// Loại của ứng viên.
        /// Chính Thức 
        /// Thời vụ.
        /// </summary>
        [Field]
        public EnumTypeOfCandidate? TypeOfCandidate { get; set; }
        /// <summary>
        /// Trạng thái cuộc gọi
        /// </summary>
        [Field]
        public EnumCallStatus? CallStatus { get; set; }
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
        /// Gọi lại
        /// </summary>
        [Field]
        public DateTime? CallBack { get; set; }
        /// <summary>
        /// Thời gian bắt đầu công việc
        /// </summary>
        [Field]
        public DateTime? StartWork { get; set; }
        /// <summary>
        /// Dán cho ai đó
        /// </summary>
        [Field]
        public long? AssignTo { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [Field]
        public DateTime? CreateAt { get; set; }
        #endregion

        public FormCandidate(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }
    }
}
