using Microsoft.AspNetCore.Http;

namespace AZWeb.Module
{
    public interface IUrlVirtual
    {
        IQueryCollection UrlVirtual { get; }
    }
}
