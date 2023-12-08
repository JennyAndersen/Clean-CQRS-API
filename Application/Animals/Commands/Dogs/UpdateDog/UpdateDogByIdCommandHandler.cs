
using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateDogByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToUpdate = await _animalRepository.GetByIdAsync(request.Id) as Dog
                   ?? throw new NotFoundException($"Dog with ID {request.Id} not found.");

            dogToUpdate.Name = request.UpdatedDog.Name;
            dogToUpdate.DogBreed = request.UpdatedDog.Breed;
            dogToUpdate.DogWeight = request.UpdatedDog.Weight;

            await _animalRepository.UpdateAsync(dogToUpdate);

            return dogToUpdate;
        }
    }
}
