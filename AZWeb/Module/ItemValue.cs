using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
namespace AZWeb.Module
{
    public class ItemValue
    {
        public string Display { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public object Item { get; set; }
    }
    public static class ItemValueExtend
    {
        public static List<ItemValue> GetListDataByDataType(this Type DataType, HttpContext httpContext, string txtDefault = "", Expression<Func<object, bool>> whereFunc =null)
        {
            var Data = new List<ItemValue>();
            if (DataType.IsEnum)
                foreach (var item in Enum.GetValues(DataType))
                {
                    if(whereFunc==null|| whereFunc.Compile()(item))
                        Data.Add(item.GetItemValueByEnum());
                }
            else if (DataType.IsTypeFromInterface<IEntityService>())
            {
                var service = httpContext.RequestServices.GetService(DataType) as IEntityService;
                System.Collections.IList rsData=null;
                if (whereFunc != null)
                {
                    var fnGetAll = DataType.GetMethod("Select");
                    if (fnGetAll != null)
                    {
                        rsData = (System.Collections.IList)fnGetAll.Invoke(service, new[] { whereFunc });
                    }
                }
                else
                {
                    var fnGetAll = DataType.GetMethod("GetAll");
                    if (fnGetAll != null)
                    {
                        rsData = (System.Collections.IList)fnGetAll.Invoke(service, null);
                    }
                }
                if (rsData != null) {
                    foreach (var item in rsData)
                    {
                        Data.Add(item.GetItemValue());
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtDefault))
            {
                Data.Insert(0, new ItemValue() { Display = txtDefault, Value = null });
            }
            return Data;
        }
        public static ItemValue GetItemValue(this object obj)
        {
            var itemValue = new ItemValue();
            var TypeObject = obj.GetType();
            foreach (var item in TypeObject.GetProperties())
            {
                if (item.GetAttribute<FieldValueAttribute>() != null)
                {
                    itemValue.Value = item.GetValue(obj);
                    itemValue.Name = item.Name;
                }
                if (item.GetAttribute<FieldDisplayAttribute>() != null)
                {
                    itemValue.Display = string.Format("{0}", item.GetValue(obj));
                }
            }
            itemValue.Item = obj;
            return itemValue;
        }
        public static ItemValue GetItemValueByEnum(this object obj)
        {
            var itemValue = new ItemValue();
            var TypeObject = obj.GetType();
            itemValue.Value = obj;
            itemValue.Name = obj.ToString();
            itemValue.Item = obj;
            var memInfo = TypeObject.GetMember(obj.ToString());
            var field = memInfo[0].GetAttribute<FieldAttribute>();
            if (field != null)
            {
                itemValue.Display = field.Display;
            }
            else
            {
                itemValue.Display = itemValue.Name;
            }
            return itemValue;
        }
    }
}
