using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule, IUrlVirtual
    {
        public bool HasPermission(string permissionCode)
        {
            return User != null && User.HasPermission(permissionCode);
        }
        public long? TenantId { get; set; }
        public UserInfo User { get; }
        public bool IsAuth { get => User != null; }
        public QueryString UrlVirtual { get; }
        public HttpContext HttpContext { get; }
        public HttpRequest Request { get => HttpContext.Request; }
        public HttpResponse Response { get => HttpContext.Response; }
        public IServiceProvider RequestServices { get => HttpContext.RequestServices; }
        public bool IsAjax { get; }
        private string path { get; }

        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            this.IsAjax = HttpContext.IsAjax();
            UrlVirtual = HttpContext.Request.QueryString;

            this.HttpContext.BindFormAttributeTo(this);
            this.HttpContext.BindQueryAttributeTo(this); var pathFull = this.GetType().FullName;
            var indexEnd = pathFull.LastIndexOf('.');
            var indexStart = pathFull.IndexOf(".Web.");
            path = pathFull.Substring(indexStart + 1, indexEnd - indexStart - 1).Replace(".", "/");
            //BindServiceAttribute
            foreach (var item in this.GetType().GetProperties())
            {
                if (item.GetAttribute<BindServiceAttribute>() != null) 
                {
                    item.SetValue(this, RequestServices.GetService(item.PropertyType));
                }
            }
            foreach (var item in this.GetType().GetFields())
            {
                if (item.GetAttribute<BindServiceAttribute>() != null &&item.GetValue(this)==null)
                {
                    item.SetValue(this, RequestServices.GetService(item.FieldType));
                }
            }
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                this.User = this.HttpContext.User.GetUserInfo();
                IPermissionService permissionService = this.HttpContext.GetService<IPermissionService>();
                if (permissionService != null) {
                    this.User.PermissionActive = permissionService.GetPermissionByUserId(this.User.Id).ToList();
                }
                this.HttpContext.Items[TagHelperBase.KeyUser] = this.User;
            }
        }
        public virtual void BeforeRequest() { IntData(); }
        public virtual void AfterRequest() { }
        protected virtual void IntData(){ }
        protected virtual string GetPathMoule() {
            return path;
        }
    }
}
