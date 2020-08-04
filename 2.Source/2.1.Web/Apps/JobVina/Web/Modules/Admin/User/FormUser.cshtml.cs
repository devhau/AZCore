using AZCore.Database.SQL;
using AZCore.Extensions;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.User
{
    public class FormUser : PageManage<UserService,UserModel, UpdateUser>
    {
        public FormUser(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách tài khoản";
        }
        protected override void AddWhere(QuerySQL Q)
        {
            Q.Join<TenantUserModel>((t1, t2) => "{0}={1}".Frmat(t1.GetColumn("Id"), t2.GetColumn("UserId")),AZCore.Database.Enums.JoinType.LeftOuterJoin);
            Q.JoinOnly<TenantUserModel, TenantModel>((t1, t2) => "{0}={1}".Frmat(t1.GetColumn("TenantId"), t2.GetColumn("Id")),AZCore.Database.Enums.JoinType.LeftOuterJoin);
            //base.AddWhere(Q);
        }
        protected override void AddQuerySQL(QuerySQL Q)
        {
            Q.SetColumn<UserModel>(p=>p.GetColumn("*"));
            Q.AddColumn<TenantUserModel>(p=>p.GetColumn("Status", "UserStatus"));
            Q.AddColumn<TenantModel>(p => p.GetColumn("Name", "TenantName"));
        }
    }
}
