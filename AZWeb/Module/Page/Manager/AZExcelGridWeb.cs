using AZCore.Excel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AZWeb.Module.Page.Manager
{
    public class AZExcelGridWeb: ExcelGrid
    {
        HttpContext httpContext;
        Dictionary<Type, List<ItemValue>> DataDic { get; set; }
        public AZExcelGridWeb(HttpContext httpContext):base() {
            this.httpContext = httpContext;
            this.DataDic = new Dictionary<Type, List<ItemValue>>();
        }
        protected override void AddHeader(List<IExcelColumn> columns)
        {
            base.AddHeader(columns);
            
            foreach (var item in columns) {
                if (item.DataType != null && !this.DataDic.ContainsKey(item.DataType))
                {
                    this.DataDic[item.DataType] = item.DataType.GetListDataByDataType(this.httpContext, " ");
                }
            }
        }
        protected override object GetValueByType(Type type, object value)
        {
            var itemDic = this.DataDic[type].Where(p => p.Value!=null&&p.Value.Equals(value)).FirstOrDefault();
            if (itemDic != null)
            {
                return itemDic.Display;
            }
            return base.GetValueByType(type, value);
        }
    }
}
