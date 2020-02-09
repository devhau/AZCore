using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Authorization
{
    public class Permission
    {
        public Permission Parent { get; set; }
        public string Name { get; set; }
    }
}
