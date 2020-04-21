using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AZCore.Extensions
{
    public static class TypeExtensions
    {
       
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type type)
        {
            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }       
        public static TAttribute GetAttribute<TAttribute>(this Type type)
        {
            return type.GetAttributes<TAttribute>().FirstOrDefault();
        }
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo type)
        {
            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo type)
        {
            return type.GetAttributes<TAttribute>().FirstOrDefault();
        }
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MethodInfo type)
        {
            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }
        public static TAttribute GetAttribute<TAttribute>(this MethodInfo type)
        {
            return type.GetAttributes<TAttribute>().FirstOrDefault();
        }
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this PropertyInfo type)
        {
            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }

        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo type)
        {
            return type.GetAttributes<TAttribute>().FirstOrDefault();
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this FieldInfo type)
        {
            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }

        public static TAttribute GetAttribute<TAttribute>(this FieldInfo type)
        {
            return type.GetAttributes<TAttribute>().FirstOrDefault();
        }

        public static IEnumerable<Type> GetTypeFromInterface<TInterface>(this Type type)
        {
            return type.Assembly.GetTypeFromInterface<TInterface>();
        }
        public static IEnumerable<Type> GetTypeFromInterface<TInterface>(this Assembly ass)
        {
            var typeInterface = typeof(TInterface);
            return ass.GetTypes().Where(t => t.IsTypeFromInterface<TInterface>());
        }

        public static IEnumerable<PropertyInfo> GetPropertyByAttribute<TAttribute>(this Type type) {
            return type.GetProperties().Where(p => p.GetAttribute<TAttribute>() != null);
        }
        public static bool IsTypeFromInterface<TInterface>(this Type type)
        {
            var typeInterface = typeof(TInterface);
            return type.IsClass && !type.IsAbstract && type.GetInterfaces().Any(i => i == typeInterface);
        }
        /// <summary>
        /// Khởi tạo một đối tượng theo Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type, params object[] param)
        {
            return (T)type.CreateInstance(param);
        }
        public static T CreateInstance<T>(this Type type, Action<T> action, params object[] param)
        {
            var t= (T)type.CreateInstance(param);
            action(t);
            return t;
        }
        /// <summary>
        /// Khởi tạo một đối tượng theo Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateInstance(this Type type, params object[] param)
        {
            return Activator.CreateInstance(type, param);
        }

    }
}
