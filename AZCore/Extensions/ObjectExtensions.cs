using AZCore.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AZCore.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj,bool isEncode=false) {

            if (obj == null) return "";
            if(isEncode)
            return HttpUtility.UrlPathEncode(Uri.EscapeUriString(JsonConvert.SerializeObject(obj)));
            return JsonConvert.SerializeObject(obj);
        }
        public static TClass ToObject<TClass>(this string obj)
        {
            return JsonConvert.DeserializeObject(obj,typeof(TClass)).As<TClass>();
        }
        public static TType To<TType>(this object obj) {
            return (TType)(obj.ToType(typeof(TType)));
        }
        public static object ToType(this object obj,Type typeObj) {
            var typeConvert = SqlTypeDescriptor.Inst.GetConverter(typeObj);
            return typeConvert.ConvertFrom(obj);
        }
        public static TTarget CopyTo<TTarget>(this object obj) where TTarget:class,new()
        {
            if (obj == null) return null;
            var obj2 = new TTarget();
            var objType2 = typeof(TTarget);
            var objType = obj.GetType();
            foreach (var item in objType2.GetProperties()) {
                var pro =objType.GetProperty(item.Name);
                if (pro != null&& pro.CanRead&&item.CanWrite) {
                    item.SetValue(obj2, pro.GetValue(obj).ToType(item.PropertyType));
                }
            }
            return obj2;
        }
        public static bool IsNull(this object obj) {
            return obj == null;
        }

        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null || string.IsNullOrEmpty(obj.ToString());
        }
        public static bool Is<IsType>(this object obj) {
            return obj is IsType;
        }
        public static AsType As<AsType>(this object obj)
        {
            return (AsType)obj;
        }

    }
}
