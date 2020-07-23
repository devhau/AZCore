using AZCore.Database;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace JobVina.Common
{
    public class PageUpdate<TService, TModel> : UpdateModule<TService, TModel>
        where TModel : IEntity, new()
        where TService : EntityService<TService, TModel>
    {
        public PageUpdate(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
