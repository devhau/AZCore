using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AZWeb.Module.MultiTenancy.Parsers
{
    public interface IRequestParser
    {
        Task<string> ParseRequestAsync(HttpContext httpContext, CancellationToken cancellationToken = default);
    }
}
