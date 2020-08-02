using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class PostService : EntityService< PostModel>, IAZTransient
    {
        public PostService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    [TableInfo(TableName = "az_common_post")]
    public class PostModel : EntityTenantModel<long>
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(Length =256)]
        public string Title { get; set; }
        [Field]
        public long CatalogId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(Length = 256)]
        public string Keyword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field]
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field]
        public bool IsHot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field]
        public bool IsPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(Length = 500)]
        public string Banner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Field(Length = 500)]
        public string Images { get; set; }
    }
}
