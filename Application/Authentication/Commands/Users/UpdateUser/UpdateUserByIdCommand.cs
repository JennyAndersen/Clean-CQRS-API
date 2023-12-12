using Application.Dtos;
using Domain.Models;
using Domain.Models.Animal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
