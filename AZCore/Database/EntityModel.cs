using AZCore.Database.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database
{
    public class EntityModel
    {
    }
    public class EntityModel<TModel>: EntityModel where TModel:EntityModel
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
        [Field(IsKey = true)]
        public virtual TKey Id { get; set; }
    }
}
