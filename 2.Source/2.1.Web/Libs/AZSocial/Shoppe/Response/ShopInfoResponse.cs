using AZSocial.Base;
using Google.Protobuf.WellKnownTypes;
using System;

namespace AZSocial.Shoppe.Response
{
    public class ShopInfoResponse : IDataResponse
    {
        public long shop_id { get; set; }
        public string shop_name { get; set; }
        public string shop_description { get; set; }
        public string[] videos { get; set; }
        public string[] images { get; set; }
        public bool enable_display_unitno { get; set; }
        public int item_limit { get; set; }
        public ShoppeStatus status { get; set; }
        public int installment_status { get; set; }
        public bool is_cb { get; set; } 
        public int non_pre_order_dts { get; set; }
        public long auth_time { get; set; }
        public long expire_time { get; set; }

    }
}
