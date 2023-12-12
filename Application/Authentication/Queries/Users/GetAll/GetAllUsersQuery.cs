using Domain.Models;
using MediatR;

namespace Application.Authentication.Queries.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
