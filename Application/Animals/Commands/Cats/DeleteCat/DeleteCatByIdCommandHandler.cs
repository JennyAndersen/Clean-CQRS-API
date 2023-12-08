using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;

namespace Application.Animals.Commands.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, bool>
    {
        private readonly IAnimalRepository _animalRepository;
        public DeleteCatByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<bool> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Animal catToDelete = await _animalRepository.GetByIdAsync(request.DeletedCatId);

            if (catToDelete == null)
            {
                return false;
            }

            await _animalRepository.DeleteAsync(request.DeletedCatId);
            return true;
        }
    }
}