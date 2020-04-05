using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Utilities
{
    public interface IStartup
    {
        Type GetType(string type);
    }
}
