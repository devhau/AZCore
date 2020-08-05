using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZWeb.Module.Page.Manager
{
    public abstract class SearchModule<TService, TModel> : PageModule, IEntity, IPagination
        where TModel : IEntity, new()
        where TService : EntityService<TModel>
    {
        public SearchModule(IHttpContextAccessor httpContext) : base(httpContext)
        {
            Service = this.HttpContext.GetService<TService>();
        }
        protected TService Service;
        public List<TModel> Data;
        [BindQuery]
        public int PageIndex { get; set; }
        public int PageMax { get; set; }
        [BindQuery(FromName = "rows")]
        public int PageSize { get; set; } = 20;
        public long PageTotal { get; set; }
        public long PageTotalAll { get; set; }
        [BindQuery]
        public string sort { get; set; }
        public string ColumSort { get; set; }
        public SortType Sort { get; set; }

        protected override void IntData()
        {
            if (!sort.IsNullOrEmpty())
            {
                var cols = sort.Split(' ');
                if (cols.Length == 2)
                {
                    ColumSort = cols[0];
                    Sort = cols[1] == "asc" ? SortType.ASC : (cols[1] == "desc" ? SortType.DESC : SortType.None);
                }
            }
            base.IntData();
        }
        protected virtual void AddWhere(QuerySQL Q)
        {
        }
        protected virtual void AddOperatorWhere(QuerySQL Q)
        {
            foreach (var key in this.HttpContext.Request.Query.Keys)
            {
                var item = ItemOperator.Parse(key, this.HttpContext.Request.Query[key][0]);
                if (item != null)
                {
                    Q.AddWhere(item.Item, item.Value, item.Operator);
                }
            }
        }
        protected virtual void AddQuerySQL(QuerySQL Q)
        {

        }
        public virtual List<TModel> GetSearchData()
        {
            var proper = this.GetType().GetPropertyByQuerySearch();
            Action<QuerySQL> actionWhere = (T) =>
            {
                foreach (var p in proper)
                {
                    if (p.Property.GetValue(this) != null)
                        T.AddWhere(p.Property.Name, p.Property.GetValue(this), p.OperatorSQL);
                }
                AddWhere(T);
                AddOperatorWhere(T);
            };
            this.PageTotalAll = Service.ExecuteNoneQuery((T) =>
            {

                T.SetColumn("count(0)");

            });
            this.PageTotal = Service.ExecuteNoneQuery((T) =>
            {
                T.SetColumn("count(0)");
                actionWhere(T);
            });
            this.PageMax = PageSize > 0 ? (int)Math.Ceiling(PageTotal / (decimal)PageSize) : 0;
            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
            return Service.ExecuteQuery((T) =>
            {
                T.Pagination(PageIndex, PageSize);
                if (!string.IsNullOrEmpty(this.ColumSort))
                {
                    T.AddOrder(this.ColumSort, this.Sort);
                }
                actionWhere(T);
                AddQuerySQL(T);
            }).ToList();
        }

        public virtual IView Get()
        {
            Data = GetSearchData();
            return View();
        }
    }
}
