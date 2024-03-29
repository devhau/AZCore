﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Utility
{
   public static class Singleton<T> where T : new()
    {
        private static ConcurrentDictionary<Type, T> _instances = new ConcurrentDictionary<Type, T>();

        public static T Instance
        {
            get
            {
                return _instances.GetOrAdd(typeof(T), (t) => new T());
            }
        }
    }
}
