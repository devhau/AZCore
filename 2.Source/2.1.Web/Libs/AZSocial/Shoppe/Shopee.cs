using AZCore.Utility;
using AZSocial.Base;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
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
    public partial class Shopee : SocialBase<Shopee>
    {
#if DEBUG
        public Shopee():this("841121", "e53bb1e6294712d1b17f71ce407a386fdc2c9935b0d44f7ae1acc1e9e6498343")
        { 
        }
        public const string Url = "https://partner.uat.shopeemobile.com";
#else
        public const string Url = "https://partner.shopeemobile.com";
#endif
        public Shopee(string partnerID,string key) {
            PartnerID = partnerID;
            Key = key;
        }
        protected string PartnerID { get; set; } 
        protected string Key { get; set; }
        public string GetLinkAuth(string redirectUrl = "") {
            return string.Format("{0}/api/v1/shop/auth_partner?id={1}&token={2}&redirect={3}", Url, PartnerID, (Key + redirectUrl).ToSHA256HexHash(), redirectUrl);
        }
    }
}
