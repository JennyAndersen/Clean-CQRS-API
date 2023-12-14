using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Birds.GetByColor
{
    public class GetBirdsByColorQuery : IRequest<List<Bird>>
    {
        public required string Color { get; set; }
    }
}
