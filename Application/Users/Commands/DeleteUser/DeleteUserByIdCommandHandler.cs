using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Authentication.Commands.DeleteUser
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
