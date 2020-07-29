﻿using AZCore.Database.SQL;
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
            Q.Join<TenantUserModel>((t1, t2) => "{0}.Id={1}.UserId".Frmat(t1, t2));
            Q.AddWhere((t) => "{0}.TenantId".Frmat(t.Tables[1]),this.User.TenantId);
            //base.AddWhere(Q);
        }
        protected override void AddQuerySQL(QuerySQL Q)
        {
            Q.SetColumn("{0}.*,{1}.Status as UserStatus".Frmat(Q.Tables[0],Q.Tables[1]));
        }
    }
}
