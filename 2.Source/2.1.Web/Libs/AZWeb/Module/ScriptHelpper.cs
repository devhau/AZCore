using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb
{
    public static class ScriptHelpper
    {
        public static string Script(string id,string fn,string param="")
        {
            return string.Format("{0}(\"{1}\")",fn,id,param);
        }
        public static string ScriptQuery(string id, string fn, string param = "")
        {
            return string.Format("$(\"{1}\").{0}({2})", fn, id, param);
        }
        public static string FormManager(string id, string param = "")
        {
            return ScriptQuery(id, "AZManager", param);
        }
    }
}
