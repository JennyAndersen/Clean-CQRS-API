using Application.Animals.Commands.Birds.DeleteBird;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = await _userRepository.GetByIdAsync(request.DeletedUserId);

            if (userToDelete == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(request.DeletedUserId);
            return true;
        }
    }
}
