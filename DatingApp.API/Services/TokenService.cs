using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingApp.API.Interfaces;
using DatingApp.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Services
{
    public class TokenService : ITokenService
    {
        // get key to encrypt & decrypt with same key
        private readonly SymmetricSecurityKey _key;
        // init constructor to inject config
        public TokenService(IConfiguration config)
        {
            // set _key to encode token key
            // TokenKey is configured in appsetting.Dev
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

        }
        // implement interface 
        public string CreateToken(Value user)
        {
            // create claims
            var claims = new List<Claim> {
                // add new claim
                // register nameId & store username to nameId
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName )
            };

            // create creds passing in key in Symmetric
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor {
                // subject - claims
                Subject = new ClaimsIdentity(claims),
                // expires - how long should this token last
                Expires = DateTime.Now.AddDays(7),
                // creds - pass in our creds
                SigningCredentials = creds
            };

            // token handler 
            var tokenHandler = new JwtSecurityTokenHandler();

            // creating token, calling CreateToken, passing on tokenhandler & pass in tokendescriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // write token, calling WriteToken on tokenhandler & passing in our token
            return tokenHandler.WriteToken(token);

        }
    }
}
