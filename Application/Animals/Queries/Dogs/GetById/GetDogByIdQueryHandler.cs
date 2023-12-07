using Domain.Models;
using Infrastructure.Data;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Animals.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly AnimalDbContext _dataDbContext;

        public GetDogByIdQueryHandler(AnimalDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _dataDbContext.Dogs.FirstOrDefault(dog => dog.Id == request.Id)! ?? throw new NotFoundException("Dog not found.");
            return Task.FromResult(wantedDog);
        }
    }
}
