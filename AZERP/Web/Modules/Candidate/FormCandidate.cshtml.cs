using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Candidate
{
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt", Width = 100,FormatString ="{0:dd/MM/yyyy}")]
    [TableColumn(Title = "Họ Tên", FieldName = "FullName", Width = 100)]
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
        public FormCandidate(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }
    }
}
