using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateBirdByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            var birdToUpdate = await _animalRepository.GetByIdAsync(request.Id) as Bird
                   ?? throw new NotFoundException($"Bird with ID {request.Id} not found.");

            birdToUpdate.Name = request.UpdatedBird.Name;
            birdToUpdate.CanFly = request.UpdatedBird.CanFly;
            birdToUpdate.Color = request.UpdatedBird.Color;

            await _animalRepository.UpdateAsync(birdToUpdate);

            return birdToUpdate;
        }
    }
}