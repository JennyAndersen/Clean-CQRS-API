using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Birds.GetById
{
    public class GetBirdByIdQuery : IRequest<Bird>
    {
        public GetBirdByIdQuery(Guid birdId)
        {
            AnimalId = birdId;
        }

        public Guid AnimalId { get; }
    }
}
