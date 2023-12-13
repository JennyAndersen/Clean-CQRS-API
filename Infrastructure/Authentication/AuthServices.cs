using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthServices(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string username, string plainTextPassword)
        {
            var user = _userRepository.GetUserByUsername(username);

            if (user == null)
            {
                throw new Exception($"User with username '{username}' not found");
            }

            if (!VerifyPassword(plainTextPassword, user.UserPasswordHash))
            {
                throw new Exception("Invalid password");
            }

            return user;
        }

        private static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);

            if (!isPasswordValid)
            {
                throw new Exception("Password verification failed");
            }

            return true;
        }


        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(s: _configuration["JwtSettings:SecretKey"]); //Implement null handling

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
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
