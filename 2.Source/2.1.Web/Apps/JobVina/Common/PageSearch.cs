using AZCore.Database;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobVina.Common
{
    public class PageSearch<TService, TModel> : SearchModule<TService, TModel>
          where TModel : IEntity, new()
        where TService : EntityService<TModel>
    {
        public PageSearch(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobHome";
        }
    }
}
