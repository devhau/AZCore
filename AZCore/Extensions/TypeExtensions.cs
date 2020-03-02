using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace AZCore.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type type) {

            return type.GetCustomAttributes(true).OfType<TAttribute>();
        }

        public static TAttribute GetAttribute<TAttribute>(this Type type)
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

        public static IEnumerable<Type> GetTypeFromInterface<TInterface>(this Type type)
        {
            return type.Assembly.GetTypeFromInterface<TInterface>();
        }
            public static IEnumerable<Type> GetTypeFromInterface<TInterface>(this Assembly ass) {
            var typeInterface = typeof(TInterface);
            return ass.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i == typeInterface));
        }

    }
}
