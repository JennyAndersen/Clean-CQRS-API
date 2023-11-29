using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Authentication.Queries.Users
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
