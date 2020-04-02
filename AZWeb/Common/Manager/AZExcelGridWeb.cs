using AZCore.Excel;
using AZWeb.TagHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Manager
{
    public class AZExcelGridWeb: AZExcelGrid
    {
        HttpContext httpContext;
        Dictionary<Type, List<AZItemValue>> DataDic { get; set; }
        public AZExcelGridWeb(HttpContext httpContext):base() {
            this.httpContext = httpContext;
            this.DataDic = new Dictionary<Type, List<AZItemValue>>();
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
            var itemDic = this.DataDic[type].Where(p => p.ItemValue.Equals(value)).FirstOrDefault();
            if (itemDic != null)
            {
                return itemDic.ItemDisplay;
            }
            return base.GetValueByType(type, value);
        }
    }
}
