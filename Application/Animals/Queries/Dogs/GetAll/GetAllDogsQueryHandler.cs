using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Dogs.GetAll
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllDogsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogs = await _animalRepository.GetAllDogsAsync();
            return allDogs;
        }
    }
}
