using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Candidate
{
    [TableColumn(Title = "Họ Tên", FieldName = "FullName", Width = 150)]
    [TableColumn(Title = "Email", FieldName = "Email", Width = 100)]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber", Width = 150)]
    [TableColumn(Title = "Trạng thái", FieldName = "IsActive")]
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
