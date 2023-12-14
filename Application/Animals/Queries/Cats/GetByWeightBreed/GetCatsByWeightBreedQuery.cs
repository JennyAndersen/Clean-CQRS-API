using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Cats.GetByWeightBreed
{
    public class GetCatsByWeightBreedQuery : IRequest<List<Cat>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}
