using AZCore.Database;
using AZCore.Database.Attr;
using System.Data;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user")]
    public class AZUser<TEntity, TKey> : EntityBase<TEntity, TKey> where TEntity: AZUser<TEntity, TKey>
    {
        [Field(Length =200)]
        public string FullName { get; set; }
        [Field(Length = 15)] 
        public string PhoneNumber { get; set; }
        [Field(Length =200)] 
        public string Email { get; set; }
        [Field(Length =200)] 
        public string UserName { get; set; }
        [Field(Length =128)] 
        public string Password { get; set; }
        public AZUser(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
