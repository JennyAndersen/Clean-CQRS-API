using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.AnimalUsers.Commands.UpdateAnimalUserByUserID
{
    public class UpdateAnimalUserByUserIdCommandHandler : IRequestHandler<UpdateAnimalUserByUserIdCommand, bool>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public UpdateAnimalUserByUserIdCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<bool> Handle(UpdateAnimalUserByUserIdCommand request, CancellationToken cancellationToken)
        {
            AnimalUser animalUser = await _animalUserRepository.GetAnimalUserByIdAsync(request.AnimalUserId);

            if (animalUser == null)
            {
                throw new NotFoundException("AnimalUser not found");
            }

            animalUser.UserId = request.NewUserId;

            await _animalUserRepository.UpdateAnimalUserAsync(animalUser);

            return true;
        }
    }
}
