using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Authentication.Queries.Users.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsers = await _userRepository.GetAllUsersAsync();
            return allUsers;
        }
    }
}
