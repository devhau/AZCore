using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AZWeb.Module.MultiTenancy.Parsers
{
    /// <summary>
    /// The tenant can be identified by a custom domain name that they have configued and mapped.
    /// </summary>
    public class DomainParser : RequestParser
    {
        /// <summary>
        /// Retrieves the value of the full domain hostname from a request.
        /// </summary>
        /// <param name="httpContext">The request to retrieve the full domain hostname from.</param>
        /// <returns>The value of the full domain hostname.</returns>
        public override Task<string> ParseRequestAsync(HttpContext httpContext, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpContext.Request.Host.Host);
        }
    }
}
