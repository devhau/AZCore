﻿using AZCore.Extensions;
using AZCore.Utility;
using AZSocial.Base;
using AZSocial.Shoppe.Request;
using AZSocial.Shoppe.Response;
using System;
using System.Diagnostics;
using System.Net;

namespace AZSocial.Shoppe
{
    /*
    Test Shop Info
    Test Shop ID 305492
    Test Shop URL https://uat.shopee.vn/shop/305492
    Test Shop Account open.SANDBOX.841121
    Test Shop Original Password QNJTPmBG
    OTP: 123456
    */
    public partial class Shopee : RestApi<Shopee>
    {
#if DEBUG
        public Shopee():this(841121, "e53bb1e6294712d1b17f71ce407a386fdc2c9935b0d44f7ae1acc1e9e6498343")
        {
        }
        public const string Url = "https://partner.uat.shopeemobile.com";
#else
        public const string Url = "https://partner.shopeemobile.com";
#endif

       
        public Shopee(long partnerID,string key) {
            PartnerID = partnerID;
            Key = key;
        }
        protected long PartnerID { get; set; } 
        protected string Key { get; set; }
        protected string Version { get; set; } = "v1";
        protected long ShopId { get; set; }
        public void SetShopId(long _shopId) => this.ShopId = _shopId;
        protected string urlApiBase=> "{0}/api/{1}/".Frmat(Url,this.Version);
        protected override void BeforeSendRequest(WebRequest request, MethodHttp method, string url, string dataJson = null)
        {
            string Signature = "{0}|{1}".Frmat(url, dataJson).ToHMACSHA256HexHash(this.Key);
            request.Headers.Add(HttpRequestHeader.Authorization, Signature);
            base.BeforeSendRequest(request, method, url, dataJson);
        }
        public override string GetUrlBase(string url)
        {
            return "{0}{1}".Frmat(this.urlApiBase, url); ;
        }
        public string GetLinkAuth(string redirectUrl = "")
        {
            return string.Format("{0}shop/auth_partner?id={1}&token={2}&redirect={3}", urlApiBase, PartnerID, (Key + redirectUrl).ToSHA256HexHash(), redirectUrl);
        }
        public ResponseData<ShopInfoResponse> GetInfo(long ShopId = 0)
        {
            return this.DoPost<ShopInfoResponse, RequestBase>("shop/get",
                p =>
                {
                    p.partner_id = this.PartnerID;
                    p.shopid = ShopId > 0 ? ShopId : this.ShopId;
                }
                , null,
                (_, response) =>
                {

                    foreach (var key in response.Headers.AllKeys)
                    {
                        Debug.WriteLine("Key={0};Value={1}".Frmat(key, response.Headers[key]));
                    }
                });
        }
        public ResponseData<ShopInfoResponse> UpdateInfo(Action<ShopInfoRequest> acRequest, long ShopId = 0)
        {
            return this.DoPost<ShopInfoResponse, ShopInfoRequest>("shop/update", p => { acRequest?.Invoke(p); p.partner_id = this.PartnerID; p.shopid = ShopId > 0 ? ShopId : this.ShopId; });
        }
    }
}

