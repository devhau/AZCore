using AZCore.Database.Attr;
using System;

namespace AZCore.Database
{
    public interface IEntityModel
    {
         bool IsLock { get; set; }
         bool IsActive { get; set; }
         bool IsDelete { get; set; }
         DateTime CreateAt { get; set; }
         DateTime? UpdateAt { get; set; }
         DateTime? DeleteAt { get; set; }
    }
    public class EntityModel<TModel>: IEntityModel where TModel: IEntityModel
    {
        [Field]
        public bool IsLock { get; set; }
        [Field]
        public bool IsActive { get; set; }
        [Field]
        public bool IsDelete { get; set; }
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
        public virtual TKey Id { get; set; }
    }
}
