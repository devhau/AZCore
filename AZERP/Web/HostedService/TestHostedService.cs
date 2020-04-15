using AZWeb.Module;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AZERP.Web.HostedService
{
    public class TestHostedService : HostedServiceBase
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Debug.WriteLine(DateTime.Now);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
