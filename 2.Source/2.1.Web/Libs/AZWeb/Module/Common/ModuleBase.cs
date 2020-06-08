﻿using AZCore.Extensions;
using AZCore.Identity;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using System;

namespace AZWeb.Module.Common
{
    public class ModuleBase : IModule, IUrlVirtual
    {
        public bool HasPermission(string permissionCode)
        {
            return User != null && User.HasPermission(permissionCode);
        }
        public ITenant Tenant { get; }
        public long? TenantId { get => this.Tenant?.Id; }
        public UserInfo User { get; }
        public bool IsAuth { get => User != null; }
        public QueryString UrlVirtual { get; }
        public HttpContext HttpContext { get; }
        public HttpRequest Request { get => HttpContext.Request; }
        public HttpResponse Response { get => HttpContext.Response; }
        public IServiceProvider RequestServices { get => HttpContext.RequestServices; }
        public IServiceProvider RequestScopeServices { get => HttpContext.Items[AZWebConstant.ScopeService] as IServiceProvider; }
        public bool IsAjax { get; }

        public ModuleBase(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            this.IsAjax = HttpContext.IsAjax();
            UrlVirtual = HttpContext.Request.QueryString;

            this.HttpContext.BindFormAttributeTo(this);
            this.HttpContext.BindQueryAttributeTo(this); 
            //BindServiceAttribute
            foreach (var item in this.GetType().GetProperties())
            {
                BindServiceAttribute att = null;
                if ((att=item.GetAttribute<BindServiceAttribute>()) != null) 
                {
                    item.SetValue(this, RequestServices.GetService(item.PropertyType));
                }
            }
            foreach (var item in this.GetType().GetFields())
            {
                BindServiceAttribute att = null;
                if ((att = item.GetAttribute<BindServiceAttribute>()) != null &&item.GetValue(this)==null)
                {
                    item.SetValue(this, RequestServices.GetService(item.FieldType));
                }
            }
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                this.User = HttpContext.Items[AZWebConstant.KeyUser] as UserInfo;
            }

            this.Tenant = HttpContext.Items[AZWebConstant.KeyTenant] as ITenant;

        }
        public virtual IView GoToAuth()
        {
            return GoToRedirect("/dang-nhap.az");
        }
        public virtual IView GoToHome()
        {
            return GoToRedirect("/");
        }
        public virtual IView GoToRedirect(string url)
        {
            return new RedirectView() { Module = this, RedirectToUrl = url };
        }
        public virtual void BeforeRequest() { IntData(); }
        public virtual void AfterRequest() { }
        protected virtual void IntData(){ }
      
    }
}
