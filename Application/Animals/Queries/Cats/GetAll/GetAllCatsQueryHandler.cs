using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Cats.GetAll
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAllCatsQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCats = await _animalRepository.GetAllCatsAsync();
            return allCats;
        }
    }
}
