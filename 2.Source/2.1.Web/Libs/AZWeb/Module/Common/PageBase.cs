using Microsoft.AspNetCore.Http;

namespace AZWeb.Module.Common
{
    public class PageBase : ApiController
    {
        private string path { get; }
        public PageBase(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            var pathFull = this.GetType().FullName;
            var indexEnd = pathFull.LastIndexOf('.');
            var indexStart = pathFull.IndexOf(".Web.");
            path = pathFull.Substring(indexStart + 1, indexEnd - indexStart - 1).Replace(".", "/");
        }
        protected virtual string GetPathMoule()
        {
            return path;
        }
    }
}
