using System.Net.Http;

namespace AZSocial.Base
{
    sealed class SocialBase: ISocial
    {
        private HttpClient _Client { get; } = new HttpClient();
    }
}
