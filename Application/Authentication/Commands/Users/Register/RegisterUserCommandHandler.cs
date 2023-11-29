using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Authentication.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly MockDatabase _mockDatabase;

        public RegisterUserCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            var isUsernameUnique = !_mockDatabase.Users.Any(u => u.UserName == request.NewUser.Username);
            if (!isUsernameUnique)
            {
                throw new InvalidOperationException("Username is already taken");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.Username,
                UserPassword = request.NewUser.Password,
            };

            _mockDatabase.Users.Add(newUser);

            return Task.FromResult(newUser);
        }
    }
}
