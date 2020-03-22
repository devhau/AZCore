﻿using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Utility;

namespace AZCore.Identity
{

    [TableInfo(TableName = "az_user")]
    public class AZUser<TEntity, TKey> : EntityModel<TEntity, TKey> where TEntity: AZUser<TEntity, TKey>
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
        [Field(Length = 128)]
        public string Salt { get; set; }
        [Field(Length = 200)]
        public string Address { get; set; }
        public void SetPassword(string pass) 
        {
            this.Salt = HashPassword.CreateSalt();
            this.Password = HashPassword.Create(pass, this.Salt);
        }
        /// <summary>
        /// Kiểm tra mật khẩu xem có đúng không.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passowrd"></param>
        /// <returns></returns>
        public bool  HasPassword(string pass)
        {
            return this.Password == HashPassword.Create(pass, this.Salt);
        }
    }
}
