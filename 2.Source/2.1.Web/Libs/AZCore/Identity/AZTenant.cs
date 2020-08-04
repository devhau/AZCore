using AZCore.Database;
using AZCore.Database.Attributes;
using System;

namespace AZCore.Identity
{
    public interface ITenantService {
        ITenant GetTenantByCanonicalName(string name);
        ITenant GetTenantById(long id);
    }
    [TableInfo(TableName = "az_common_tenant")]
    public class AZTenant : EntityModel<long>, ITenant
    {
        /// <summary>
        /// Tên đối tác
        /// </summary>
        [Field(Length = 200,Display ="Tên đối tác")]
        public string Name { get; set; }
        /// <summary>
        /// Email đối tác
        /// </summary>
        [Field(Length = 100)]
        public string Email { get; set; }
        /// <summary>
        /// Website
        /// </summary>
        [Field(Length = 256)]
        public string Website { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Field(Length = 20,Display ="Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [Field(Length = 1000,Display ="Mô tả")]
        public string Description { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Field(Length = 500,Display ="Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the canonical name for this tenant.
        /// </summary>
        [Field(Length = 200,Display ="Tên thương hiệu")]
        public string CanonicalName { get; set; }
        /// <summary>
        /// Gets or sets the normalized canonical name for this tenant.
        /// </summary>
        [Field(Length = 200)]
        public string NormalizedCanonicalName { get; set; }
        /// <summary>
        /// Gets or sets the domain name for this tenant.
        /// </summary>
        [Field(Length = 200,Display ="Tên miền")] 
        public string DomainName { get; set; }
        /// <summary>
        /// A random value that must change whenever a tenant is persisted to the store.
        /// </summary>
        [Field(Length = 200,Display ="Code")]
        public string TenantCode { get; set; } = Guid.NewGuid().ToString();
    }
    public interface ITenant {
        string Name { get; set; }
        long Id { get; set; }
        /// <summary>
        /// Gets or sets the canonical name for this tenant.
        /// </summary>
        string CanonicalName { get; set; }

        /// <summary>
        /// Gets or sets the normalized canonical name for this tenant.
        /// </summary>
         string NormalizedCanonicalName { get; set; }
        /// <summary>
        /// Gets or sets the domain name for this tenant.
        /// </summary>
        string DomainName { get; set; }

        /// <summary>
        /// A random value that must change whenever a tenant is persisted to the store.
        /// </summary>
        string TenantCode { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        EntityStatus? Status { get; set; }
    }
}
