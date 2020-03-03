using AZCore.Database.Attr;
using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Test
{
    public class AZUser : AZUser<AZUser, long>
    {
        [Field(IsAutoIncrement =true,IsKey =true)]
        public override long Id { get => base.Id; set => base.Id = value; }
       
    }
}
