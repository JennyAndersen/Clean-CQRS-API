using Domain.Models;
using MediatR;

namespace Application.Animals.Queries.Cats.GetAll
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
