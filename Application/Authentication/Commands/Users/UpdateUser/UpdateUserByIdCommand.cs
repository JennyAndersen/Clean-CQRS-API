using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Authentication.Commands.Users.UpdateUser
{
    public class UpdateUserByIdCommand : IRequest<User>
    {
        public UpdateUserByIdCommand(UserRegistrationDto updatedUser, Guid id)
        {
            UpdatedUser = updatedUser;
            Id = id;
        }

        public UserRegistrationDto UpdatedUser { get; }
        public Guid Id { get; }
    }
}
