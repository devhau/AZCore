using AZWeb.Module;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HubUrl("UserOnline")]
    public class ChatHub : HubBase<ChatHub>
    {
        protected override string GroupName => "UserOnline";

        public async Task SendMessage(string userId, string message)
        {
           await this.SendUserAsync(userId, "ReceiveMessage",this.User.Id, message);
        }
        protected override async Task UpdateUserAsync()
        {
            await this.SendAllAsync("UserOnline", UserOnline.Values.ToList());
        }
    }
}
