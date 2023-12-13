using Domain.Dtos;
using MediatR;

namespace Application.AnimalUsers.Queries.GetAllAnimalUsers
{
    public class GetAllAnimalUsersQuery : IRequest<List<GetAnimalUsersDto>>
    {
    }
}
