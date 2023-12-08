
using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public UpdateCatByIdCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            var catToUpdate = await _animalRepository.GetByIdAsync(request.Id) as Cat
                   ?? throw new NotFoundException($"Cat with ID {request.Id} not found.");

            catToUpdate.Name = request.UpdatedCat.Name;
            catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
            catToUpdate.CatBreed = request.UpdatedCat.Breed;
            catToUpdate.CatWeight = request.UpdatedCat.Weight;

            await _animalRepository.UpdateAsync(catToUpdate);

            return catToUpdate;
        }
    }
}