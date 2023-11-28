using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Queries
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
    {
        private readonly IConfiguration _configuration;
        private readonly MockDatabase _mockDatabase;
        private readonly AuthServices _authServices;

        public UserLoginQueryHandler(IConfiguration configuration, MockDatabase mockDatabase, AuthServices services)
        {
            _configuration = configuration;
            _mockDatabase = mockDatabase;
            _authServices = services;
        }

        public Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = _authServices.AuthenticateUser(request.Username, request.Password);

            if (user == null)
            {
                // You might want to throw a custom exception here instead of returning null
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _authServices.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}
