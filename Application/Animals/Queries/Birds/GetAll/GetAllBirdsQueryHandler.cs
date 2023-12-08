using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Birds.GetAll
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllBirdsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirds = await _animalRepository.GetAllBirdsAsync();
            return allBirds;
        }
    }
}