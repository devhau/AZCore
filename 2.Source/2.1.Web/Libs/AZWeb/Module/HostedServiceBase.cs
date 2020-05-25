using AZCore.Domain;
using Microsoft.Extensions.Hosting;

namespace AZWeb.Module
{
    public abstract class HostedServiceBase: BackgroundService, IAZDomain
    {
    }
}
