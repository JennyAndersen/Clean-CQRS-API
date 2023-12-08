using Domain.Interfaces;
using Domain.Models.Animal;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetDogByIdQueryHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = await _animalRepository.GetByIdAsync(request.AnimalId) as Dog
                         ?? throw new NotFoundException("Dog not found.");

            return wantedDog;
        }
    }
}
