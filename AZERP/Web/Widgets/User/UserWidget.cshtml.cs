using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;

namespace AZERP.Web.Widgets.User
{
    [WidgetInfo(Name = "Tài khoản")]
    public class UserWidget : WidgetBase
    {
        [BindService]
        public UserService UserService { get; set; }
        public UserWidget(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            this.Setting.Title = "Số lượng tài khoản";            
            this.Setting.Type = WidgetType.InfoBox;
            this.Setting.Value = UserService.ExecuteNoneQuery((T) =>T.SetColumn("count(0)"));
            this.Setting.Icon = "fas fa-users";
            base.IntData();
        }
    }
}
