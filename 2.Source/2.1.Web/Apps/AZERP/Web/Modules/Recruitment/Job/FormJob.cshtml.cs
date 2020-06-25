using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Recruitment.Job
{
    [TableColumn(Title = "Tiêu đề", FieldName = "Title", Width = 130)]
    [TableColumn(Title = "Công ty", FieldName = "CompanyId", Width = 100, DataType = typeof(CompanyWorkerService))]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address", Width = 150)]
    [TableColumn(Title = "Lĩnh vực", FieldName = "ProfessionName", Width = 150)]
    [TableColumn(Title = "Lương từ", FieldName = "SalaryFrom", Width = 150)]
    [TableColumn(Title = "Lương đến", FieldName = "SalaryTo", Width = 150)]
    [TableColumn(Title = "Áp dụng từ ngày", FieldName = "JobFrom", Width = 100)]
    [TableColumn(Title = "Áp dụng đến ngày", FieldName = "JobTo", Width = 100)]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    public class FormJob : ManageModule<JobInfoService, JobInfoModel, FormUpdateJob>
    {
        public FormJob(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý danh sách việc làm";
        }
     
    }
}
