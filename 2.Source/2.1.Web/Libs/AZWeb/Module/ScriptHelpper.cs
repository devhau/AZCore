using AZCore.Extensions;
namespace AZWeb
{
    public static class ScriptHelpper
    {
        public static string ScriptNew(string id, string fn, string param = "", bool isId = false)
        {
            return isId? string.Format("new {0}(\"#{1}\")", fn, id, param) : string.Format("new {0}(\".{1}\")", fn, id, param);
        }
        public static string Script(string id,string fn,string param="")
        {
            return string.Format("{0}(\"{1}\")",fn,id,param);
        }
        public static string ScriptQuery(string id, string fn, string param = "", bool isId = false)
        {
            return isId ? string.Format("$(\"#{1}\").{0}({2})", fn, id, param): string.Format("$(\".{1}\").{0}({2})", fn, id, param);
        }
        public static string FormManager(string id, string param = "",bool isId=false)
        {
            return ScriptQuery(id, "Manager", param, isId);
        }
    }
}
