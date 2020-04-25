using System;

namespace AZWeb.Utilities
{
    public interface IStartup
    {
        Type GetType(string type);
    }
}
