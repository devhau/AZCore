using Microsoft.AspNetCore.Http;

namespace AZWeb.Module
{
    public interface IUrlVirtual
    {
        QueryString UrlVirtual { get; }
    }
}
