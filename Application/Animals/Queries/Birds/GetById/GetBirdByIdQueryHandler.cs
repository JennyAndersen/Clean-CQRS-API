using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Birds.GetById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetBirdByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = await _animalRepository.GetByIdAsync(request.AnimalId) as Bird
                         ?? throw new NotFoundException($"No bird found with ID '{request.AnimalId}'.");

            return wantedBird;
        }
    }
}
