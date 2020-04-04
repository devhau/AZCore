using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Common.Module
{
    public interface IUrlVirtual
    {
        IQueryCollection UrlVirtual { get; }
    }
}
