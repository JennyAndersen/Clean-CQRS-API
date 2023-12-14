using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Cats.GetByWeightBreed
{
    public class GetCatsByWeightBreedQueryHandler : IRequestHandler<GetCatsByWeightBreedQuery, List<Cat>>
    {
        private readonly IAnimalRepository _animalRepository;
        public GetCatsByWeightBreedQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Cat>> Handle(GetCatsByWeightBreedQuery request, CancellationToken cancellationToken)
        {
            List<Cat> catsByWeightBreed = await _animalRepository.GetCatsByWeightBreedAsync(request.Breed, request.Weight);
            return catsByWeightBreed;
        }
    }
}
