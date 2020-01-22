using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration;
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token
            };
        }
        public JwtSecurityToken CreateJwtToken(TokenOptions tokenOptions,User user,
            SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:_tokenOptions.Issuer,
                audience:_tokenOptions.Audience,
                claims:SetClaims(user,operationClaims),
                notBefore:DateTime.Now,
                expires:_accessTokenExpiration,
                signingCredentials:signingCredentials
                );
            return jwt;
        }
        public IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName(user.FirstName);
            claims.AddUserName(user.UserName);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
