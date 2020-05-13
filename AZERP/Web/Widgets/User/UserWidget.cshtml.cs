using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.User
{
    public class UserWidget : WidgetBase
    {
        [BindService]
        public UserService UserService { get; set; }
        public UserWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            this.Title = "Số lượng tài khoản";            
            this.Type = WidgetType.InfoBox;
            this.Value = UserService.ExecuteNoneQuery((T) =>T.SetColumn("count(0)"));
            this.Icon = "fas fa-users";
            base.IntData();
        }
    }
}
