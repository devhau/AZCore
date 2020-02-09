
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace AZCore.Web.Transformer
{
    public class HyphenateRouteParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null)
            {
                return null;
            }
            return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
