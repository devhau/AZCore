using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZCore.Web.Common
{
    public class AZRequest
    {
        public string VirtualPath { get; set; }
        public string RealPath { get; set; }
        public AZLayoutWapper Layout { get; set; } = AZLayoutWapper.NoLayout;
    }
}
