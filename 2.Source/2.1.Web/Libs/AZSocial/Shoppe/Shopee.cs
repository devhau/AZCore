using AZCore.Utility;
using AZSocial.Base;
using AZSocial.Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
        protected string GetUrlApi() => string.Format("{0}/api/{1}/", Url,this.Version);

        public override void BeforeSendRequest(WebRequest request, MethodHttp method, string url, string Data = null)
        {
            string Signature = string.Format("{0}|{1}", url, Data).ToHMACSHA256HexHash(this.Key);
            request.Headers.Add(HttpRequestHeader.Authorization, Signature);
            base.BeforeSendRequest(request, method, url, Data);
        }
        public string GetLinkAuth(string redirectUrl = "") 
        {
            return string.Format("{0}shop/auth_partner?id={1}&token={2}&redirect={3}", GetUrlApi(), PartnerID, (Key + redirectUrl).ToSHA256HexHash(), redirectUrl);
        }
        public ResponseData<ShopInfoResponse> GetInfo(long ShopId=0) {
            return this.DoPost<ShopInfoResponse>(string.Format("{0}shop/get", GetUrlApi()),new ShopeeRequestBase() { partner_id=this.PartnerID,shopid= ShopId>0? ShopId:this.ShopId});
        }
    }
}

