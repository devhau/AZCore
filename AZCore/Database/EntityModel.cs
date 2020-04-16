using AZCore.Database.Attributes;
using System;

namespace AZCore.Database
{
    public interface IEntity 
    { 
    }
    public interface IEntityModel: IEntity
    {
        EntityStatus Status { get; set; }
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
        [Field]
        public EntityStatus Status { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        [Field]
        public long CreateBy { get; set; }
        [Field] 
        public long? UpdateBy { get; set; }
        [Field] 
        public long? DeleteBy { get; set; }
        [Field]
        public DateTime CreateAt { get; set; }
        [Field]
        public DateTime? UpdateAt { get; set; }
        [Field]
        public DateTime? DeleteAt { get; set; }
    }
    public class EntityModel<TModel,TKey>: EntityModel<TModel> where TModel: EntityModel<TModel>
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        [FieldValue]
        public virtual TKey Id { get; set; }
    }
}
