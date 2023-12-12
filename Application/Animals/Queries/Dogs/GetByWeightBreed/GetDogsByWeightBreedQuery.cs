using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetByWeightBreed
{
    public class GetDogsByWeightBreedQuery : IRequest<List<Dog>>
    {
        public int? Weight { get; set; }
        public string? Breed { get; set; }
    }
}
