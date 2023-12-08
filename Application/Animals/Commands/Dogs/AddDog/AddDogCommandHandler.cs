using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public AddDogCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewDog.Name,
                DogBreed = request.NewDog.Breed,
                DogWeight = request.NewDog.Weight,
            };

            await _animalRepository.AddAsync(dogToCreate);

            return dogToCreate;
        }
    }
}
