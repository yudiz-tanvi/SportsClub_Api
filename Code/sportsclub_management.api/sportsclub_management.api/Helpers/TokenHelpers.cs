using Microsoft.IdentityModel.Tokens;
using sportsclub_management.models.Configs;
using sportsclub_management.models.Response;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sportsclub_management.api.Helpers
{
	public class TokenHelpers : IDisposable
    {
        #region Object Declarations and Constructor

        private ICrypto Crypto { get; set; }

        public TokenHelpers(ICrypto Crypto)
        {
            this.Crypto = Crypto;
        }

        #endregion

        #region Get Access Token

        public string GetAccessToken(AuthConfigs AuthConfig, LoginResponse response)
        {
            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sid, Crypto.Encrypt(response.Id.ToString())),
                new Claim(JwtRegisteredClaimNames.Email, Crypto.Encrypt(response.Email)),
                new Claim(JwtRegisteredClaimNames.GivenName, Crypto.Encrypt(response.Name)),
                new Claim("Username", Crypto.Encrypt(response.Username)),
                new Claim(JwtRegisteredClaimNames.Jti, Crypto.Encrypt(response.UniqueId)),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(AuthConfig.Issuer, AuthConfig.Audiance, expires: DateTime.Now.AddDays(AuthConfig.AccessExpireDays), signingCredentials: creds, claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion

        #region Dispose

        public void Dispose() => GC.SuppressFinalize(this);

        #endregion Dispose
    }
}
