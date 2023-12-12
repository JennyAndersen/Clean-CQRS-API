using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.AnimalUsers.Commands.AddAnimalUser
{
    public class AddAnimalUserCommandHandler : IRequestHandler<AddAnimalUserCommand, bool>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public AddAnimalUserCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<bool> Handle(AddAnimalUserCommand request, CancellationToken cancellationToken)
        {
            var userAnimal = new AnimalUser
            {
                UserId = request.UserId,
                AnimalId = request.AnimalId,
                // HappyTogetherIndex = request.HappyTogetherIndex,
            };

            return await _animalUserRepository.AddUserAnimalAsync(userAnimal);
        }
    }
}
