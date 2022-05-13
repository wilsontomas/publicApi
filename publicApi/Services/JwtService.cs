using publicApi.Service.ConfigurationOptions;
using publicApi.Service.Interfaces;
using publicApi.Service.UtilClasses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Service
{
    public class JwtService : IJwtService
    {
        private readonly JsonWebTokenOptions _jsonWebTokenOptions;

        public JwtService(JsonWebTokenOptions jsonWebTokenOptions)
        {
            _jsonWebTokenOptions = jsonWebTokenOptions;
        }

        public Task<JwtAuthResult> GenerateTokens(string userName, Claim[] claims, DateTime createDate)
        {
            var accessTokenExpiration = createDate.AddMinutes(_jsonWebTokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = createDate.AddMinutes(_jsonWebTokenOptions.RefreshTokenExpiration);
            var shouldAddAudienceClaim =
                string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jsonWebTokenOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jsonWebTokenOptions.Issuer,
                Expires = accessTokenExpiration,
                Audience = shouldAddAudienceClaim ? _jsonWebTokenOptions.Audience : string.Empty,
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.Run(() => new JwtAuthResult
            {
                AccessToken = tokenHandler.WriteToken(token),
                AccessTokenExpiration = accessTokenExpiration
               
            });
        }

        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string authToken)
        {
            if (string.IsNullOrWhiteSpace(authToken))
            {
                throw new SecurityTokenException("Invalid token");
            }
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(authToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _jsonWebTokenOptions.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jsonWebTokenOptions.Secret)),
                        ValidAudience = _jsonWebTokenOptions.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(_jsonWebTokenOptions.ClockSkew)
                    },
                    out var validatedToken);

            return (principal, validatedToken as JwtSecurityToken);
        }
    }
}
