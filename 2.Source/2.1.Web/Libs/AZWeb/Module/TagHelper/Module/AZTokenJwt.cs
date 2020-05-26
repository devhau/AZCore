using AZWeb.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    [HtmlTargetElement("az-token-jwt")]
    public class AZTokenJwt : TagHelperBase
    {
        public TokenJwtType Type = TokenJwtType.Javascript;
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            if (this.User != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AZCoreExtensions.key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = (ClaimsIdentity)this.HttpContext.User.Identity,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                // AZCore.UserId
                var token = tokenHandler.CreateEncodedJwt(tokenDescriptor);
                this.AddJS(string.Format("AZCore.Token= \"{0}\"; AZCore.UserId={1};", token, this.User.Id));
            }
            output.SuppressOutput();
            return Task.CompletedTask;
        }
    }
    public enum TokenJwtType { 
        Javascript,
        Header
    }
}
