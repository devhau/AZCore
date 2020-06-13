using NUnit.Framework;
using System.Text.RegularExpressions;

namespace AZWeb.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //http://localhost:5001/thong-tin-viec-lam/123-tuyen-dung-cong-nhan-canon-bac-thang-long.az
            var url = "http://localhost:5001/thong-tin-viec-lam/123-tuyen-dung-cong-nhan-canon-bac-thang-long.az";
            var rs = Regex.Matches(url, @"thong-tin-viec-lam/(\d+)-(.*?).az");
            Assert.Pass();
        }
    }
}