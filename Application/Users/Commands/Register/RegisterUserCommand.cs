using Application.Dtos;
using Application.Exceptions;
using Application.Validators;
using Domain.Models;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public class RegisterUserCommand : IRequest<User>, IValidate
    {
        public RegisterUserCommand(UserRegistrationDto newUser)
        {
            NewUser = newUser;
        }

        public UserRegistrationDto NewUser { get; }

        public void Validate()
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(NewUser.Username))
            {
                validationErrors.Add("Username cannot be empty.");
            }

            if (string.IsNullOrEmpty(NewUser.Password))
            {
                validationErrors.Add("Password cannot be empty.");
            }

            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Validation failed", validationErrors);
            }
        }
    }
}
