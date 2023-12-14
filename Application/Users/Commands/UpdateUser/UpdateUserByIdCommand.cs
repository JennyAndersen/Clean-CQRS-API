using Application.Dtos;
using Application.Validators;
using Domain.Models;
using MediatR;

namespace Application.Authentication.Commands.UpdateUser
{
    public class UpdateUserByIdCommand : IRequest<User>, IValidate
    {
        public UpdateUserByIdCommand(UserRegistrationDto updatedUser, Guid id)
        {
            UpdatedUser = updatedUser;
            Id = id;
        }

        public UserRegistrationDto UpdatedUser { get; }
        public Guid Id { get; }

        public void Validate()
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(UpdatedUser.Username))
            {
                validationErrors.Add("Username cannot be empty.");
            }

            if (string.IsNullOrEmpty(UpdatedUser.Password))
            {
                validationErrors.Add("Password cannot be empty.");
            }

            if (validationErrors.Count > 0)
            {
                throw new Common.BadRequestException("Validation failed", validationErrors);
            }
        }
    }
}
