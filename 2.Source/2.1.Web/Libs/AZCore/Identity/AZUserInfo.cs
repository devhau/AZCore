using AZCore.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AZCore.Identity
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public long? TentaintId { get; set; }
        public List<string> PermissionActive { get; set; }
        public virtual bool HasPermission(string PermissonCode) {
            return string.IsNullOrEmpty(PermissonCode)|| (this.PermissionActive != null && this.PermissionActive.IndexOf(PermissonCode)>=0);
        }
    }
    public static class UserInfoExtention {

        public static List<Claim> CreateClaim( this UserInfo user) {
            var claims = new List<Claim>();
            claims.Add(new Claim("az.core.UserId", user.Id.ToString()));
            claims.Add(new Claim("az.core.UserName", user.UserName));
            claims.Add(new Claim("az.core.FullName", user.FullName));
            claims.Add(new Claim("az.core.Email", user.Email));
            claims.Add(new Claim("az.core.PhoneNumber", user.PhoneNumber));
            return claims;

        }
        public static UserInfo GetUserInfo(this ClaimsPrincipal claimsPrincipal) {
            var user = new UserInfo();
            user.Id = claimsPrincipal.Identities.First().FindFirst("az.core.UserId").Value.To<long>();
            user.UserName = claimsPrincipal.Identities.First().FindFirst("az.core.UserName").Value;
            user.FullName = claimsPrincipal.Identities.First().FindFirst("az.core.FullName").Value;
            user.Email = claimsPrincipal.Identities.First().FindFirst("az.core.Email").Value;
            user.PhoneNumber = claimsPrincipal.Identities.First().FindFirst("az.core.PhoneNumber").Value;
            return user;
        }
    }
}
