using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Cats.GetById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetCatByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _animalRepository.GetByIdAsync(request.AnimalId) as Cat
                         ?? throw new NotFoundException("Cat not found.");

            return wantedCat;
        }
    }
}