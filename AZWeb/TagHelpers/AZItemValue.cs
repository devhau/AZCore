using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.TagHelpers
{
    public class AZItemValue
    {
        public string ItemDisplay { get; set; }
        public string ItemName { get; set; }
        public object ItemValue { get; set; }
        public object Item { get; set; }
    }
    public static class AZItemValueExtend {
        public static List<AZItemValue> GetListDataByDataType(this Type DataType, HttpContext httpContext,string txtDefault="") {
            var Data = new List<AZItemValue>();
            if (DataType.IsEnum)
            {
                foreach (var item in Enum.GetValues(DataType))
                {
                    Data.Add(item.GetItemValueByEnum());
                }
            }
            else if (DataType.IsTypeFromInterface<IEntityService>())
            {
                var service = httpContext.RequestServices.GetService(DataType) as IEntityService;
                var fnGetAll = DataType.GetMethod("GetAll");
                if (fnGetAll != null)
                {
                    var rsData = (System.Collections.IList)fnGetAll.Invoke(service, null);
                    foreach (var item in rsData)
                    {
                        Data.Add(item.GetItemValue());
                    }
                }
                if (!string.IsNullOrEmpty(txtDefault)) {

                    Data.Insert(0, new AZItemValue() { ItemDisplay=txtDefault,ItemValue=0});
                }
            }
            
            return Data;
        }
        public static AZItemValue GetItemValue(this object obj) { 
            var itemValue = new AZItemValue();
            var TypeObject = obj.GetType();
            foreach (var item in TypeObject.GetProperties()) {
                if (item.GetAttribute<FieldValueAttribute>()!=null) {
                    itemValue.ItemValue = item.GetValue(obj);
                    itemValue.ItemName = item.Name;
                }
                if (item.GetAttribute<FieldDisplayAttribute>() != null)
                {
                    itemValue.ItemDisplay = string.Format("{0}",item.GetValue(obj));
                }
            }
            return itemValue;
        }
        public static AZItemValue GetItemValueByEnum(this object obj)
        {
            var itemValue = new AZItemValue();
            var TypeObject = obj.GetType();
            itemValue.ItemValue = obj;
            itemValue.ItemName = obj.ToString();
            var memInfo = TypeObject.GetMember(obj.ToString());
            var field = memInfo[0].GetAttribute<FieldAttribute>();
            if (field != null)
            {
                itemValue.ItemDisplay = field.Display;
            }
            else {
                itemValue.ItemDisplay = itemValue.ItemName;
            }
            return itemValue;
        }
    }
}
