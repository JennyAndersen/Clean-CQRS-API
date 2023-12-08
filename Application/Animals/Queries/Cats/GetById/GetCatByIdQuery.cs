using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Cats.GetById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catId)
        {
            AnimalId = catId;
        }

        public Guid AnimalId { get; }
    }
}