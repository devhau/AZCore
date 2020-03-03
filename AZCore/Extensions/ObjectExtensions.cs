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
