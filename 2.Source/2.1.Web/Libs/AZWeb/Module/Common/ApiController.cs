using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AZWeb.Module.Common
{
    public abstract class ApiController : ModuleBase
    {
        public ApiController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        #region --- Json ----
        public virtual IView Json(object dataJson)
        {
            return Json(string.Empty, dataJson, HttpStatusCode.OK);
        }
        public virtual IView Json(string Message)
        {
            return Json(Message, string.Empty, HttpStatusCode.OK);
        }
        public virtual IView Json(string Message, HttpStatusCode status)
        {
            return Json(Message, string.Empty, status);
        }
        public virtual IView Json(string Message, object data)
        {
            return Json(Message, data, HttpStatusCode.OK);
        }
        public virtual IView Json(string Message, object data, HttpStatusCode status)
        {
            return new JsonView() { Module = this, Data = data, StatusCode = status, Message = Message };
        }
        #endregion
        
    }
}
