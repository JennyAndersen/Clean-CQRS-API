using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = request.NewUser.Username,
                UserPasswordHash = hashedPassword,
            };

            await _userRepository.AddUserAsync(newUser);

            return newUser;
        }
    }
}
