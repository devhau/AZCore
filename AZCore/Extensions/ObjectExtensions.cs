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
    }
}
