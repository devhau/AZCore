using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Utility;
using System.Text.Json.Serialization;

namespace AZCore.Identity
{
    [TableInfo(TableName = "az_user")]
    public class AZUser<TEntity> : EntityModel<TEntity, long> where TEntity : AZUser<TEntity>
    {
        [FieldDisplay]
        [Field(Length =200)]
        public string FullName { get; set; }
        [Field(Length = 15)] 
        public string PhoneNumber { get; set; }
        [Field(Length =200)] 
        public string Email { get; set; }
        [Field(Length =200)] 
        public string UserName { get; set; }
        [JsonIgnore]
        [Field(Length =128)] 
        public string Password { get; set; }
        [JsonIgnore]
        [Field(Length = 128)]
        public string Salt { get; set; }
        [Field(Length = 200)]
        public string Address { get; set; }
        public void SetPassword(string pass) 
        {
            this.Salt = AzPassword.CreateSalt();
            this.Password = AzPassword.Create(pass, this.Salt);
        }
        /// <summary>
        /// Kiểm tra mật khẩu xem có đúng không.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passowrd"></param>
        /// <returns></returns>
        public bool HasPassword(string pass)
        {
            return AzPassword.Validate(pass, this.Salt, this.Password);
        }
    }
}
