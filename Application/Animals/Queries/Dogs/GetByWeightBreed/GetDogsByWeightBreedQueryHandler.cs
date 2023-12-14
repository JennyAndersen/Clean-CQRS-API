using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetByWeightBreed
{
    public class GetDogsByWeightBreedQueryHandler : IRequestHandler<GetDogsByWeightBreedQuery, List<Dog>>
    {
        private readonly IAnimalRepository _animalRepository;
        public GetDogsByWeightBreedQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Dog>> Handle(GetDogsByWeightBreedQuery request, CancellationToken cancellationToken)
        {
            List<Dog> dogsByWeightBreed = await _animalRepository.GetDogsByWeightBreedAsync(request.Breed, request.Weight);
            return dogsByWeightBreed;
        }
    }
}
