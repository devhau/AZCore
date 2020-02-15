using AZCore.Web.Common.Module;

namespace AZCore.HRM.Web.Modules.Home
{
    public class FormHome:ModuleBase
    {
        public string id { get; set; }
        public object Get(){
           return View();
        }
    }
}
