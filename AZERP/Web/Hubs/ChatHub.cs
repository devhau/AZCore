using AZWeb.Module;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Web.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HubUrl("UserOnline")]
    public class ChatHub : HubBase<ChatHub>
    {
        protected override string GroupName => "UserOnline";

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, this.User?.FullName);
        }
        protected override async Task UpdateUserAsync()
        {
            await this.SendAllAsync("UserOnline", UserOnline.Values.ToList());
        }
    }
}
