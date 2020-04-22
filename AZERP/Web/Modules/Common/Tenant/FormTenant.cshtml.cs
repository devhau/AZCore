using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.Tenant
{
    [TableColumn(Title = "Vai trò", FieldName = "Name")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 ,DataType =typeof(EntityStatus))]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString ="{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType =typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    public class FormTenant : ManageModule<TenantService, TenantModel, FormUpdateTenant>
    {
        public FormTenant(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý đối tác sử dụng dịch vụ";
        }
    }
}
