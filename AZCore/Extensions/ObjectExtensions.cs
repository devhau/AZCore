using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) {

            if (obj == null) return "";
            return JsonConvert.SerializeObject(obj); 
        }
        public static TClass ToObject<TClass>(this string obj)
        {
            return JsonConvert.DeserializeObject(obj,typeof(TClass)).As<TClass>();
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
                    item.SetValue(obj2, pro.GetValue(obj));
                }
            }
            return obj2;
        }
        public static bool IsNull(this object obj) {
            return obj == null;
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
