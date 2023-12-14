using Domain.Models;
using MediatR;

namespace Application.Authentication.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}
