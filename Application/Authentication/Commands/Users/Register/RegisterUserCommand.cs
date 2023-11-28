using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Authentication.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterUserCommand(UserRegistrationDto newUser)
        {
            NewUser = newUser;
        }

        public UserRegistrationDto NewUser { get; }
    }
}
