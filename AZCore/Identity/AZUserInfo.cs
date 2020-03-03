using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Identity
{
    public class UserInfo
    {
        public  long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
