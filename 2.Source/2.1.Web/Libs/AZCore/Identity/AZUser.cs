using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Utility;
using System.Text.Json.Serialization;

namespace AZCore.Identity
{
    public enum Gender : int
    {
        [Field(Display = "Chưa chọn")] None = 0,
        [Field(Display = "Nam")] Male = 1,
        [Field(Display = "Nữ")] Female = 2,
        [Field(Display = "Khác")] Other = 3,
    }
    [TableInfo(TableName = "az_common_user")]
    public class AZUser : EntityModel<long>
    {
        [FieldDisplay]
        [Field(Length =200, Display = "Họ tên")]
        public string FullName { get; set; }
        [Field(Length = 15,Display ="Số điện thoại")] 
        public string PhoneNumber { get; set; }
        [Field(Length =200)] 
        public string Email { get; set; }
        [Field(Display ="Giới tính")]
        public Gender Gender { get; set; }
        [Field(Length =200,Display ="Tài khoản")] 
        public string UserName { get; set; }
        [Field(Length = 200,Display ="Địa chỉ")]
        public string Address { get; set; }
        [Field(Length = 1000,Display ="Ảnh đại diện")]
        public virtual string Avatar { get; set; }
        [Field]
        public bool IsTenant { get; set; }
        [JsonIgnore]
        [Field(Length =128)] 
        public string Password { get; set; }
        [JsonIgnore]
        [Field(Length = 128)]
        public string Salt { get; set; }
        public void SetPassword()
        {
            this.SetPassword(this.Password);
        }
        public void SetPassword(string pass) 
        {
            this.Salt = AzHash.CreateSalt();
            this.Password = AzHash.CreatePassword(pass, this.Salt);
        }
        /// <summary>
        /// Kiểm tra mật khẩu xem có đúng không.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passowrd"></param>
        /// <returns></returns>
        public bool HasPassword(string pass)
        {
            return AzHash.ValidatePassword(pass, this.Salt, this.Password);
        }
    }
}
