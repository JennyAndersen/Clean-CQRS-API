using Application.Authentication.Commands.Users.Register;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.UsersController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MockDatabase _mockDatabase;
        internal readonly IMediator _mediator;

        public UserController(IConfiguration configuration, MockDatabase mockDatabase, IMediator mediator)
        {
            _configuration = configuration;
            _mockDatabase = mockDatabase;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var user = AuthenticateUser(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddDog([FromBody] UserRegistrationDto newUser)
        {
            return Ok(await _mediator.Send(new RegisterUserCommand(newUser)));
        }

        private User AuthenticateUser(string username, string password)
        {
            // Replace with your actual authentication logic
            var user = _mockDatabase.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            return user;
        }

        private string GenerateJwtToken(User user)
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