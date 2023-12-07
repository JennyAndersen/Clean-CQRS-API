using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Animal;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteBirdByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Animal birdToDelete = await _animalRepository.GetByIdAsync(request.DeletedBirdId);

            if (birdToDelete == null)
            {
                return false;
            }

            await _animalRepository.DeleteAsync(request.DeletedBirdId);
            return true;
        }
    }
}