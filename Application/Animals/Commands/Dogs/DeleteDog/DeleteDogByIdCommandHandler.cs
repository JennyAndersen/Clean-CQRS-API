using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteDogByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Animal dogToDelete = await _animalRepository.GetByIdAsync(request.DeletedDogId);

            if (dogToDelete == null)
            {
                return false;
            }

            await _animalRepository.DeleteAsync(request.DeletedDogId);
            return true;
        }
    }
}
