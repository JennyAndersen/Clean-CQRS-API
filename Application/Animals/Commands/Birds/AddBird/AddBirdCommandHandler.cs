using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IAnimalRepository _animalRepository;

        public AddBirdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly,
                Color = request.NewBird.Color
            };

            await _animalRepository.AddAsync(birdToCreate);

            return birdToCreate;
        }
    }
}