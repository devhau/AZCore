using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module;
using System.Data;
using System.Linq;

namespace AZERP.Data.Entities
{
    public class SystemCodeService : EntityService<SystemCodeService, SystemCodeModel>, IAZTransient, IGetGenCodeService<SystemCode>
    {
        public SystemCodeService(IDbConnection _connection) : base(_connection)
        {
        }
        public string GetGenCode(SystemCode Key, long? TenantId=null) {
            if (TenantId == null) {
                var systemCode = Select(p => p.Key == Key && p.Status == EntityStatus.Active).FirstOrDefault();
                if (systemCode != null)
                {
                    systemCode.PrefixIndex++;
                    this.Update(systemCode);
                    return systemCode.GenCode;
                }
            } else {
                var systemCode = Select(p => p.Key == Key && p.TenantId == TenantId && p.Status == EntityStatus.Active).FirstOrDefault();
                if (systemCode != null)
                {
                    systemCode.PrefixIndex++;
                    this.Update(systemCode);
                    return systemCode.GenCode;
                }
            }
            
            return string.Empty;
        }

        public string GetGenCode(object Key, long? TenantId = null)
        {
            return GetGenCode((SystemCode)Key, TenantId);
        }
    }
    [TableInfo(TableName = "az_system_code")]
    public class SystemCodeModel : EntityModel<SystemCodeModel,long>
    {
        /// <summary>
        /// Key để sử dụng lấy ra để tạo mã cho hệ thống
        /// </summary>
        [Field]
        public SystemCode Key { get; set; }
        /// <summary>
        /// Tiền tố của mã cần gen ra.
        /// Ví dụ: 
        /// Prefix = SPC thì mã SPC01
        /// </summary>
        [Field(Length =50)]
        public string Prefix { get; set; }
        /// <summary>
        /// Số lượng chỉ số
        /// ví dụ: len = 4 thì mã SPC0001
        /// </summary>
        [Field]
        public int Len { get; set; }
        /// <summary>
        /// Chỉ số bắt đầu.
        /// </summary>
        [Field]
        public long PrefixIndex { get; set; }=0;
        /// <summary>
        /// Đối tác
        /// </summary>
        [Field]
        public long? TenantId { get; set; }
        /// <summary>
        /// Có dùng mã đối tác không?
        /// </summary>
        [Field]
        public bool IsTenant { get; set; }
        /// <summary>
        /// Tự tạo ra mã
        /// </summary>
        public string GenCode { get { string lenZero = ""; for (int i = 0;i< Len; i++) { lenZero += "0"; } return string.Format("{0}{1:"+lenZero+"}", this.Prefix, this.PrefixIndex); } }
    }
}
