﻿using CavisProject.Application.Commoms;
using CavisProject.Application.ViewModels.RefreshTokenViewModels;
using CavisProject.Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Utils
{
    public static class GenerateJsonWebTokenString
    {
        public static RefreshTokenModel GenerateJsonWebToken(this User user, AppConfiguration appConfiguration, string secretKey, DateTime now, IEnumerable<string> roles, string refreshToken)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName" ,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var claimsArray = claims.ToArray();
            var token = new JwtSecurityToken(
                issuer: appConfiguration.JwtOptions.Issuer,
                audience: appConfiguration.JwtOptions.Audience,
                claims: claimsArray,
                expires: now.AddMinutes(5),
                signingCredentials: credentials);
            return new RefreshTokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken
            };
        }

        public static string GenerateRefreshToken()
        {
            var random = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);
            return Convert.ToBase64String(random);

        }
        public static DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }


    }
}
