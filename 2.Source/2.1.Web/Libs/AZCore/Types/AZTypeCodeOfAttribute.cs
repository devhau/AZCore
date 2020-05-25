using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Types
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class AZTypeCodeOfAttribute: Attribute
    {
        private Type type = null;
        public Type Type
        {
            get { return type; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        public AZTypeCodeOfAttribute(Type type)
        {
            this.type = type;
        }
    }
}
