using AZSocial.Base;
using System;

namespace AZSocial.Shoppe.Request
{
    public class RequestBase:IDataRequest
    {
        public RequestBase() 
        { 
        
        }
        public RequestBase(long parId, long shopId) {
            partner_id = parId;
            shopid = shopId;
        }
        public long partner_id { get; set; }
        public long shopid { get; set; }
        public long timestamp { get; set; }=new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}
