using AZCore.Domain;
using Microsoft.AspNetCore.Http;

namespace AZWeb.Common.Module
{

    public interface IModule : IAZTransient
    {
        HttpContext httpContext { get; }       
    }
}
