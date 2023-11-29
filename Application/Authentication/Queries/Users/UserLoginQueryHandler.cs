using Infrastructure.Authentication;
using MediatR;

namespace Application.Authentication.Queries.Users
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
    {
        private readonly AuthServices _authServices;

        public UserLoginQueryHandler(AuthServices services)
        {
            _authServices = services;
        }

        public Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = _authServices.AuthenticateUser(request.Username, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _authServices.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}
