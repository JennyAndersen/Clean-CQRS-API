using Domain.Models;
using MediatR;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQuery : IRequest<List<Bird>>
    {
    }
}
