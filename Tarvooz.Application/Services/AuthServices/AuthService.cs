﻿using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using Tarvooz.Domain.Entities.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;                        // Encoding ishlashi uchun

namespace Tarvooz.Application.Services.AuthServices
{
    public class AuthService:IAuthService
    {
        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWT:Expire"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),

                new Claim("Id",user.Id.ToString()),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName),
                new Claim("Role",user.Role),
                new Claim("Email",user.Email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
