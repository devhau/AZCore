﻿using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AZWeb.Module.MultiTenancy.Parsers
{
    /// <summary>
    /// Tenant canonical name can be read via a custom parser from the request.
    /// </summary>
    public class CustomParser : RequestParser
    {
        /// <summary>
        /// A custom parser of <seealso cref="Func{HttpContext, string}"/> that returns a tenant's canonical name
        /// or null using the <seealso cref="HttpContext"/> single parameter.
        /// </summary>
        public Func<HttpContext, Task<string>> Parser { get; set; }

        /// <summary>
        /// Retrieves the tenant's canonical name from the <paramref name="httpContext"/> parameter.
        /// </summary>
        /// <param name="httpContext">The request to retrieve the tenant's canonical name from.</param>
        /// <returns>The tenant's canonical name from the request.</returns>
        public override Task<string> ParseRequestAsync(HttpContext httpContext, CancellationToken cancellationToken = default)
        {
            return Parser(httpContext);
        }
    }
}
