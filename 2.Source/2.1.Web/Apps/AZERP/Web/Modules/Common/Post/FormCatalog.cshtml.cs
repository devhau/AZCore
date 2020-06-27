using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Common.Post
{
    [TableColumn(Title = "Tên nhóm", FieldName = "Title")]
    [TableColumn(Title = "Từ khóa", FieldName = "Keyword")]
    [TableColumn(Title = "Mô tả", FieldName = "Description")]
    [TableColumn(Title = "Hot", FieldName = "IsHot", TextTrue ="Đang Hot",TextFalse ="")]
    [TableColumn(Title = "Ghim nhóm", FieldName = "IsPin", TextTrue = "Đang Ghim", TextFalse = "")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150, DataType = typeof(EntityStatus))]
    [TableColumn(Title = "Thời gian tạo", FieldName = "CreateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người tạo", FieldName = "CreateBy", Width = 150, DataType = typeof(UserService))]
    [TableColumn(Title = "Thời gian cập nhật", FieldName = "UpdateAt", Width = 150, FormatString = "{0:HH:mm dd/MM/yyyy}")]
    [TableColumn(Title = "Người cập nhật", FieldName = "UpdateBy", Width = 150, DataType = typeof(UserService))]
    [ModuleInfo(
        Title = "Quản lý nhóm bài viết"
        )]
    public class FormCatalog : ManageModule<CatalogService, CatalogModel, FormUpdateCatalog>
    {
        public FormCatalog(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
