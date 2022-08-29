using Aplicacion_web.Models.DataModels;
using System.Security.Claims;

namespace Aplicacion_web.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name,userAccounts.UserName),
                new Claim(ClaimTypes.Email,userAccounts.EmailID),
                new Claim(ClaimTypes.NameIdentifier, userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            if (userAccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            }
            else if (userAccounts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id=Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }


    }
}
