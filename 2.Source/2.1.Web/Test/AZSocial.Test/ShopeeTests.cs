﻿using AZSocial.Shoppe;
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
            var test = shopee.GetInfo(305492);
            Assert.Pass();
        }
    }
}
