using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    internal interface IAZHub
    {
       
    }
    public class HubBase : Hub, IAZHub
    {
        public virtual string GroupName { get; }
        protected HubBase():base()
        {

        }
        private bool flgUser = true;
        public UserInfo _user;

        public UserInfo User
        {
            get
            {
                if (flgUser && this.Context.User.Identity.IsAuthenticated)
                {
                    _user = this.Context.User.GetUserInfo();
                }
                flgUser = false;
                return _user;
            }
        }
        internal virtual void MapRouter(HubRouteBuilder hubRouteBuilder) 
        {
        }
        //public void Send
        public override Task OnConnectedAsync()
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, string.Format("{0}_{1}", this.GroupName, this.User?.Id));
            
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, string.Format("{0}_{1}", this.GroupName, this.User?.Id));
            return base.OnDisconnectedAsync(exception);
        }
    }
    public class HubBase<IBase> : HubBase
        where IBase : HubBase<IBase>
    {
        internal override void MapRouter(HubRouteBuilder hubRouteBuilder)
        {
            var path= typeof(IBase).GetAttribute<HubUrlAttribute>()?.Url;
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }
            path = "/azhub" + path;
            hubRouteBuilder.MapHub<IBase>(path);
        }
    }
}
