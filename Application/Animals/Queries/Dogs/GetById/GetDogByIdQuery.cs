using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetById
{
    public class GetDogByIdQuery : IRequest<Dog>
    {
        public GetDogByIdQuery(Guid dogId)
        {
            AnimalId = dogId;
        }

        public Guid AnimalId { get; }
    }
}
