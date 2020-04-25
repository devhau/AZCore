using AZCore.Database;
using AZCore.Database.Attributes;
using System;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_tenant")]
    public class AZTenant<TEntity> : EntityModel<TEntity, long>, ITenant
        where TEntity : AZTenant<TEntity>
    {
        /// <summary>
        /// Tên đối tác
        /// </summary>
        [Field(Length = 200)]
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
        [Field(Length = 20)]
        public string Phone { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [Field(Length = 1000)]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the canonical name for this tenant.
        /// </summary>
        [Field(Length = 200)]
        public string CanonicalName { get; set; }
        /// <summary>
        /// Gets or sets the normalized canonical name for this tenant.
        /// </summary>
        [Field(Length = 200)]
        public string NormalizedCanonicalName { get; set; }
        /// <summary>
        /// Gets or sets the domain name for this tenant.
        /// </summary>
        [Field(Length = 200)] 
        public string DomainName { get; set; }
        /// <summary>
        /// A random value that must change whenever a tenant is persisted to the store.
        /// </summary>
        [Field(Length = 200)]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
    public interface ITenant {
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
        string ConcurrencyStamp { get; set; }
    }
}
