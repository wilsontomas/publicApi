using publicApi.Service.UtilClasses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace publicApi.Service.Interfaces
{
    public interface IJwtService
    {
        Task<JwtAuthResult> GenerateTokens(string userName, Claim[] claims, DateTime createDate);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string authToken);
    }
}
