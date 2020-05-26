using AZCore.Database;
using AZCore.Database.Attributes;
using System;
using System.Text.Json.Serialization;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_common_tenant_user")]
    public class AZTenantUser<TEntity> : IEntity
    {
        [Field(IsKey = true)]
        public long TenantId { get; set; }
        [Field(IsKey = true)]
        public long UserId { get; set; }
        [Field]
        public TenantUserStatus Status { get; set; }
        [Field]
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        [Field]
        public bool IsDelete { get; set; }
        [JsonIgnore]
        [Field]
        public long CreateBy { get; set; }
        [JsonIgnore]
        [Field]
        public long? UpdateBy { get; set; }
        [JsonIgnore]
        [Field]
        public long? DeleteBy { get; set; }
        [JsonIgnore]
        [Field]
        public DateTime CreateAt { get; set; }
        [JsonIgnore]
        [Field]
        public DateTime? UpdateAt { get; set; }
        [JsonIgnore]
        [Field]
        public DateTime? DeleteAt { get; set; }
    }
    public enum TenantUserStatus {
        [Field(Display ="Mời vào")]
        Invite,
        [Field(Display = "Xin vào")]
        Join,
        [Field(Display = "Đang hoạt động")]
        Active,
        [Field(Display = "Khóa")]
        Block,
        [Field(Display = "Từ chối")]
        Reject
    }
}
