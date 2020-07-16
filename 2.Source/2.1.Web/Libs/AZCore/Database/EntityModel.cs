using AZCore.Database.Attributes;
using System;
using System.Text.Json.Serialization;

namespace AZCore.Database
{
    public interface IEntity
    {
       
    }
    public interface ITenantEntity: IEntity
    { 
        long? TenantId { get; set; }
    }
    public interface IEntityModel: IEntity
    {
        EntityStatus? Status { get; set; }
        bool IsDelete { get; set; }
        long CreateBy { get; set; }
        long? UpdateBy { get; set; }
        long? DeleteBy { get; set; }
        DateTime CreateAt { get; set; }
        DateTime? UpdateAt { get; set; }
        DateTime? DeleteAt { get; set; }
    }

    public class EntityModel<TModel>: IEntityModel where TModel: IEntityModel
    {
        [JsonIgnore]
        [Field]
        public EntityStatus? Status { get; set; }
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
    public class EntityModel<TModel,TKey>: EntityModel<TModel> where TModel: EntityModel<TModel>
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        [FieldValue]
        public virtual TKey Id { get; set; }
    }
    public class EntityTenantModel<TModel, TKey> : EntityModel<TModel>,ITenantEntity where TModel : EntityModel<TModel>
    {
        [Field(IsKey = true, IsAutoIncrement = true)]
        [FieldValue]
        public virtual TKey Id { get; set; }
        public long? TenantId { get; set; }
    }
}
