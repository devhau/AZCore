using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.User
{
    public class UsertWidgetSetting : WidgetSetting
    {
    }
    [WidgetInfo(Name = "Tài khoản",Icon = "fas fa-users",Type = WidgetType.InfoBox)]
    public class UserWidget : WidgetBase<UsertWidgetSetting>
    {
        [BindService]
        public UserService UserService { get; set; }
        public UserWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void DoProcessData()
        {
            this.Setting.Value = UserService.ExecuteNoneQuery((T) => T.SetColumn("count(0)"));
        }
    }
}
