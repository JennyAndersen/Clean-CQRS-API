using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.AnimalUsers.Commands.DeleteAnimalUserByKey
{
    public class DeleteAnimalUserByKeyCommandHandler : IRequestHandler<DeleteAnimalUserByKeyCommand, bool>
    {
        private readonly IAnimalUserRepository _animalUserRepository;
        public DeleteAnimalUserByKeyCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<bool> Handle(DeleteAnimalUserByKeyCommand request, CancellationToken cancellationToken)
        {
            AnimalUser animalUserToDelete = await _animalUserRepository.GetByKeyAsync(request.DeletedAnimalUserKey);

            if (animalUserToDelete == null)
            {
                return false;
            }

            await _animalUserRepository.DeleteAsync(request.DeletedAnimalUserKey);
            return true;
        }
    }
}
