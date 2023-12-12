using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Authentication.Commands.Users.UpdateUser
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.Id) as User
                   ?? throw new NotFoundException($"Bird with ID {request.Id} not found.");

            userToUpdate.UserName = request.UpdatedUser.Username;

            await _userRepository.UpdateAsync(userToUpdate);

            return userToUpdate;
        }
    }
}
