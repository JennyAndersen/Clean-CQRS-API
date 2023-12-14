using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQuery : IRequest<List<Bird>>
    {
        public string color { get; set; }
    }
}
