using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Queries.Birds.GetByColor
{
    public class GetBirdsByColorQueryHandler : IRequestHandler<GetBirdsByColorQuery, List<Bird>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetBirdsByColorQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<Bird>> Handle(GetBirdsByColorQuery request, CancellationToken cancellationToken)
        {

            List<Bird> birdsByColor = await _animalRepository.GetBirdsByColorAsync(request.Color);
            return birdsByColor;

        }
    }
}

