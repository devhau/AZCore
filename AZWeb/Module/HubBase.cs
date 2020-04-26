using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    internal interface IAZHub
    {
       
    }
    public class HubBase : Hub, IAZHub
    {
        protected static Dictionary<long, UserInfo> UserOnline = new Dictionary<long, UserInfo>();
        private static Dictionary<long, List<string>> userConnect = new Dictionary<long, List<string>>();
        protected virtual string GroupName { get; }
        private bool flgUser = true;
        protected UserInfo _user;

        protected UserInfo User
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
        //((IHttpContextFeature) Context.Features[typeof(IHttpContextFeature)]).HttpContext
        public HttpContext HttpContext => ((IHttpContextFeature)Context?.Features[typeof(IHttpContextFeature)]).HttpContext;
        internal virtual void MapRouter(HubRouteBuilder hubRouteBuilder) 
        {
        }
        //public void Send
        public override async Task OnConnectedAsync()
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, string.Format("{0}", this.GroupName));
            if (this.User != null)
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, string.Format("{0}_{1}", this.GroupName, this.User?.Id));
                if (!userConnect.ContainsKey(this.User.Id))
                {
                    userConnect[this.User.Id] = new List<string>();
                }
                userConnect[this.User.Id].Add(this.Context.ConnectionId);
                if (!UserOnline.ContainsKey(this.User.Id))
                {
                    UserOnline.Add(this.User.Id, this.User);
                }
                await UpdateUserAsync();
            }
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, string.Format("{0}", this.GroupName));
            if (this.User != null)
            {
                await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, string.Format("{0}_{1}", this.GroupName, this.User.Id));
                if (userConnect.ContainsKey(this.User.Id))
                {
                    userConnect[this.User.Id].Remove(this.Context.ConnectionId);
                    if (UserOnline.ContainsKey(this.User.Id) && userConnect[this.User.Id].Count == 0)
                    {
                        UserOnline.Remove(this.User.Id);
                       await UpdateUserAsync();
                    }
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
        protected virtual Task UpdateUserAsync() {
            return Task.CompletedTask;
        }

        #region --- SendUser ---
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9, object arg10, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, object arg5, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, arg5, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, object arg4, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, arg4, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, object arg3, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, arg3, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, object arg2, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, arg2, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, object arg1, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, arg1, cancellationToken);
        }
        protected virtual async Task SendUserAsync(object UserId, string method, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(string.Format("{0}_{1}", this.GroupName, UserId)).SendAsync(method, cancellationToken);
        }
        #endregion

        #region --- SendAll --
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9, object arg10, CancellationToken cancellationToken = default) 
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, object arg9, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9,  cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, object arg8, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8,  cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6, arg7,  cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6,  CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, arg6,  cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4, object arg5,  CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, arg5, cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, object arg4,  CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3, arg4, cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2, object arg3, CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2, arg3,cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method, object arg1, object arg2,  CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method, arg1, arg2,cancellationToken);
        }
        protected virtual async Task SendAllAsync(string method, object arg1, CancellationToken cancellationToken = default)
        {
            await this.Clients.Groups(this.GroupName).SendAsync(method, arg1,  cancellationToken);
        }
         protected virtual async Task SendAllAsync(string method,CancellationToken cancellationToken = default)
        {
           await this.Clients.Groups(this.GroupName).SendAsync(method,  cancellationToken);
        }
        #endregion
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
