using AZSocial.Base;
using System;

namespace AZSocial.Shoppe
{
    public class ShopeeRequestBase:IDataRequest
    {
        public long partner_id { get; set; }
        public long shopid { get; set; }
        public long timestamp { get; set; }=new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}
