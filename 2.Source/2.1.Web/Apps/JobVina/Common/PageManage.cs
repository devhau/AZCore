using AZCore.Database;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace JobVina.Common
{
    public abstract class PageManage<TService, TModel> : ManageModule<TService, TModel> 
        where TModel : IEntity, new()
        where TService : EntityService<TModel>
    {
        protected PageManage(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "AdminLTE";
        }
    }

    public abstract class PageManage<TService, TModel, TForm> : ManageModule<TService, TModel, TForm>
        where TForm : UpdateModule<TService, TModel>
        where TModel : IEntity, new()
        where TService : EntityService<TModel>
    {
        protected PageManage(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "AdminLTE";
        }
    }
}
