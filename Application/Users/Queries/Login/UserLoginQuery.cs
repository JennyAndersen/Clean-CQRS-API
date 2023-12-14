using MediatR;

namespace Application.Authentication.Queries.Login
{
    public class UserLoginQuery : IRequest<string>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
