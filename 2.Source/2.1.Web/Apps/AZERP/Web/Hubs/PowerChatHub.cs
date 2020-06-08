using AZWeb.Module;
using AZWeb.Module.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace AZERP.Web.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HubUrl("PowerChat")]
    public class PowerChatHub: HubBase<PowerChatHub>
    {
    }
}
