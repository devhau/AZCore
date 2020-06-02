using AZSocial.Base;
using NUnit.Framework;

namespace AZSocial.Test
{
    public class SocialBaseTests
    {
        RestApi scBase = new RestApi();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
         var rs=   scBase.DoGet("https://www.google.com/").ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Pass();
        }
    }
}