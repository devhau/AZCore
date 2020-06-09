using AZSocial.Shoppe;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZSocial.Test
{
    public class ShopeeTests
    {
        Shopee shopee = new Shopee();
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //var link=  shopee.GetLinkAuth("https://k.localhost:5001/ket-noi-social.az?url=https");
           // shopee.SetShopId(305492);
           var test = shopee.GetInfo(305492);
            shopee.UpdateInfo(p => p.shop_description = "Chào duy", 305492);
            var test2 = shopee.GetInfo(305492);
            Assert.Pass();
        }
    }
}
