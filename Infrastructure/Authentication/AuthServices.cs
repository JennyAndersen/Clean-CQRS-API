﻿using Domain.Models;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class AuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly MockDatabase _mockDatabase;

        public AuthServices(IConfiguration configuration, MockDatabase mockDatabase)
        {
            _configuration = configuration;
            _mockDatabase = mockDatabase;
        }

        public User AuthenticateUser(string username, string password)
        {
            // Replace with your actual authentication logic
            var user = _mockDatabase.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}