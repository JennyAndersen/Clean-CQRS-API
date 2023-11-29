using Domain.Models;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetAll
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
    }
}
