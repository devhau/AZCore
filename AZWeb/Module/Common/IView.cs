﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Module.Common
{
    public interface IView
    {
        IModule Module { get; set; }
    }
}
