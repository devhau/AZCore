using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AZWeb.Module.MultiTenancy.Parsers
{
    public abstract class RequestParser : IRequestParser
    {
        /// <summary>
        /// Retrieves a value from a request.
        /// </summary>
        /// <param name="httpContext">The request to retrieve the value from.</param>
        /// <returns>The parsed/matched value.</returns>
        public abstract Task<string> ParseRequestAsync(HttpContext httpContext, CancellationToken cancellationToken = default);
    }
}
