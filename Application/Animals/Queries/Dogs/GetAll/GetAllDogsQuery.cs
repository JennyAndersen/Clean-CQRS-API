using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetAll
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
    }
}
