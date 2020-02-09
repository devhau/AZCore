using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Extensions
{
    public static class ConverterExtensions
    {
        private static Object ToObj(object obj) {
            return obj;
        }
        public static TValue To<TValue>(this object obj) where TValue : IComparable
        {
            var typeValue = System.Convert.GetTypeCode(default(TValue));
            switch (typeValue) {
                case TypeCode.Boolean:
                    return (TValue)ToObj(Convert.ToBoolean(obj));
                case TypeCode.Char:
                    return (TValue)ToObj(Convert.ToChar(obj));
                case TypeCode.Double:
                    return (TValue)ToObj(Convert.ToDouble(obj));
                case TypeCode.Int16:
                    return (TValue)ToObj(Convert.ToInt16(obj));
                case TypeCode.Int32:
                    return (TValue)ToObj(Convert.ToInt32(obj));
                case TypeCode.Int64:
                    return (TValue)ToObj(Convert.ToInt64(obj));
                case TypeCode.DateTime:
                    return (TValue)ToObj(Convert.ToDateTime(obj));
                case TypeCode.Decimal:
                    return (TValue)ToObj(Convert.ToDecimal(obj));
                case TypeCode.Single:
                    return (TValue)ToObj(Convert.ToSingle(obj));
            }

            return (TValue)obj;
        }
    }
}
