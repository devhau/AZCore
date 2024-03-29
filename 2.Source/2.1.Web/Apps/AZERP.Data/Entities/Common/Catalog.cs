﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class CatalogService : EntityService< CatalogModel>, IAZTransient
    {
        public CatalogService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    [TableInfo(TableName = "az_common_catalog")]
    public class CatalogModel : EntityTenantModel<long>
    {
        /// <summary>
        /// 
        /// </summary>
        [Field(Length = 256)]
        [FieldDisplay]
        public string Title { get; set; }
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
