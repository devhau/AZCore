using System;
using System.Collections.Generic;
using System.Text;

namespace AZSocial.Shoppe.Request
{
    public class ShopInfoRequest : RequestBase
    {
        public ShopInfoRequest() { }
        public ShopInfoRequest(long parId, long shopId) : base(parId, shopId)
        {
        }
        public string shop_name { get; set; }
        public List<string> images { get; set; }
        public List<string> videos { get; set; }
        public int? disable_make_offer { get; set; }
        public bool? enable_display_unitno { get; set; }
        public string shop_description { get; set; }
    }
}
