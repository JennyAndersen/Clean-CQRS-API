using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using MediatR;

namespace Application.Animals.Commands.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public AddCatCommandHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay
            };

            await _animalRepository.AddAsync(catToCreate);
            return catToCreate;
        }
    }
}
