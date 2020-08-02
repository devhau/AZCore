using AZCore.Database.SQL;
using AZCore.Extensions;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.UserCompany
{
    public class FormUserCompany : PageManage<UserService,UserModel, UpdateUserCompany>
    {
        public FormUserCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách nhân viên công ty";
        }
        protected override void AddWhere(QuerySQL Q)
        {
            Q.Join<TenantUserModel>((t1, t2) => "{0}={1}".Frmat(t1.GetColumn("Id"), t2.GetColumn("UserId")));
            Q.JoinOnly<TenantUserModel,TenantModel>((t1, t2) => "{0}={1}".Frmat(t1.GetColumn("TenantId"), t2.GetColumn("Id")));
            Q.AddWhere((t) => "TenantId",this.User.TenantId,AZCore.Database.Enums.OperatorSQL.EQUAL, Q.Tables[1]);
            //base.AddWhere(Q);
        }
        protected override void AddQuerySQL(QuerySQL Q)
        {
            Q.SetColumn(Q.Tables[0].GetColumn("*"));
            Q.AddColumn(Q.Tables[1].GetColumn("Status", "UserStatus"));
            Q.AddColumn(Q.Tables[2].GetColumn("Name", "TenantName"));
        }
    }
}
