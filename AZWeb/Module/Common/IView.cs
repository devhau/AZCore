using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public interface IView
    {
       
        IModule Module { get; set; }
    }
}
